Imports AForge.Imaging

Public Class Form1
	Dim confi As New ConvertirLineas.Configuracion
	Dim calculo As New ConvertirLineas
	Dim Ima As ImageSingle
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		PropertyGrid1.SelectedObject = confi
		With confi
			.Repeticiones = 500
			.RestaValor = 200
		End With
	End Sub

	Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
		'genera los puntos
		Dim obje As New ImageSingle(PictureBox1.Image)
		Ima = obje
		confi.Alto = PictureBox1.Image.Size.Height
		confi.Ancho = PictureBox1.Image.Size.Width

		'genero 5 X 5  puntos (para la prueba)

		Dim x, y As Integer
		Dim dx, dy As Integer

		Dim puntoslado As Integer = 30

		dx = PictureBox1.Image.Size.Width / puntoslado
		dy = PictureBox1.Image.Size.Height / puntoslado

		confi.Puntos.Clear()
		For x = 0 To (puntoslado - 1)
			Dim po As New PointF(x * dx, 0)
			confi.Puntos.Add(po)

			Dim pob As New PointF(x * dx, PictureBox1.Image.Size.Height)
			confi.Puntos.Add(pob)
		Next
		For y = 0 To (puntoslado - 1)
			Dim po As New PointF(0, y * dy)
			confi.Puntos.Add(po)

			Dim pob As New PointF(PictureBox1.Image.Size.Width, y * dy)
			confi.Puntos.Add(pob)

		Next

	End Sub

	Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
		Dim alto As Integer = PictureBox1.Image.Size.Height
		Dim ancho As Integer = PictureBox1.Image.Size.Width

		For i = 0 To 10
			Dim x As Integer = Rnd() * ancho
			Dim y As Integer = Rnd() * alto
			Dim pob As New PointF(x, y)
			confi.Puntos.Add(pob)
		Next
	End Sub

	Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
		Dim fso As New SaveFileDialog
		fso.Filter = "PNG *.png|*.png"
		If fso.ShowDialog() = DialogResult.OK Then
			PictureBox3.Image.Save(fso.FileName, Imaging.ImageFormat.Png)
		End If
	End Sub

	Private Sub AgregarBordesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarBordesToolStripMenuItem.Click
		Dim mcd As New MoravecCornersDetector()
		Dim bordes As List(Of AForge.IntPoint) = mcd.ProcessImage(PictureBox1.Image)

		Dim max As Integer = bordes.Count

		Dim i As Integer
		Dim dic As New Dictionary(Of String, AForge.IntPoint)
		For i = 0 To 60
			Dim avar As Integer = Rnd() * max

			If dic.ContainsKey(avar.ToString) = False Then
				Dim po As New PointF(bordes(avar).X, bordes(avar).Y)
				confi.Puntos.Add(po)
			Else
				i = i - 1
			End If

		Next

	End Sub

	Private Sub CalcularBordesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcularBordesToolStripMenuItem.Click
		'detector de bordes

		PictureBox1.Image = GenerarBordes(PictureBox1.Image, 2, Color.Red, True)
	End Sub

	Private Function GenerarBordes(Imagen As Bitmap, tam As Integer, Col As Color, fondo As Boolean) As Bitmap
		Dim ima As Bitmap
		If fondo Then
			ima = New Bitmap(Imagen)
		Else
			ima = New Bitmap(Imagen.Width, Imagen.Height)
		End If

		Dim g As Graphics = Graphics.FromImage(ima)
		Dim brush As New SolidBrush(Col)
		Dim pen As New Pen(brush)

		If fondo = False Then
			Dim blanco As New SolidBrush(Color.White)
			g.FillRectangle(blanco, 0, 0, Imagen.Width, Imagen.Height)
		End If

		Dim mcd As New MoravecCornersDetector()
		Dim bordes As List(Of AForge.IntPoint) = mcd.ProcessImage(Imagen)
		For Each ele In bordes
			g.FillRectangle(brush, ele.X, ele.Y, tam, tam)
		Next
		Return ima
	End Function

	Private Sub CalcularDeImagenInicialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcularDeImagenInicialToolStripMenuItem.Click
		'Dim obje As New ImageSingle(PictureBox1.Image)
		Dim obje As New ImageSingle(PictureBox1.Image)
		Dim sali As ConvertirLineas.Resultados
		sali = calculo.Convertir(obje, confi)
		PropertyGrid2.SelectedObject = sali
		PictureBox2.Image = sali.Imagen.GetImg
		PictureBox3.Image = calculo.GenerarLineas(sali)
	End Sub

	Private Sub CalcularDeBordesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcularDeBordesToolStripMenuItem.Click
		'Dim obje As New ImageSingle(PictureBox1.Image)
		Dim ima As Bitmap = GenerarBordes(PictureBox1.Image, 2, Color.Black, True)
		Dim obje As New ImageSingle(ima)
		Dim sali As ConvertirLineas.Resultados
		sali = calculo.Convertir(obje, confi)
		PropertyGrid2.SelectedObject = sali
		PictureBox2.Image = sali.Imagen.GetImg
		PictureBox3.Image = calculo.GenerarLineas(sali)
	End Sub

	Private Sub AutomaticoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomaticoToolStripMenuItem.Click
		CalculoAutomatico()
	End Sub

	Private Sub CalculoAutomatico()
		confi.Puntos.Clear()
		confi.CargarPuntosMarco(5, PictureBox1.Image)
		confi.CargaPuntosPorContorno(60, PictureBox1.Image)

		Dim ima As Bitmap = GenerarBordes(PictureBox1.Image, 2, Color.Black, True)
		Dim obje As New ImageSingle(ima)
		Dim sali As ConvertirLineas.Resultados
		sali = calculo.Convertir(obje, confi)
		PropertyGrid2.SelectedObject = sali
		PictureBox2.Image = sali.Imagen.GetImg
		PictureBox3.Image = calculo.GenerarLineas(sali)
	End Sub

	Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
		Dim fso As New OpenFileDialog
		fso.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...|All|*.*"
		If fso.ShowDialog() = DialogResult.OK Then
			If My.Computer.FileSystem.FileExists(fso.FileName) Then
				PictureBox1.Image = New Bitmap(fso.FileName)
			End If
		End If
	End Sub
	Private Sub AgregarPuntosEnContornoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarPuntosEnContornoToolStripMenuItem.Click
		'genera los puntos
		Dim obje As New ImageSingle(PictureBox1.Image)
		Ima = obje
		confi.Alto = PictureBox1.Image.Size.Height
		confi.Ancho = PictureBox1.Image.Size.Width

		'genero 5 X 5  puntos (para la prueba)

		Dim x, y As Integer
		Dim dx, dy As Integer

		Dim puntoslado As Integer = 30

		dx = PictureBox1.Image.Size.Width / puntoslado
		dy = PictureBox1.Image.Size.Height / puntoslado

		confi.Puntos.Clear()
		For x = 0 To (puntoslado - 1)
			Dim po As New PointF(x * dx, 0)
			confi.Puntos.Add(po)

			Dim pob As New PointF(x * dx, PictureBox1.Image.Size.Height)
			confi.Puntos.Add(pob)
		Next
		For y = 0 To (puntoslado - 1)
			Dim po As New PointF(0, y * dy)
			confi.Puntos.Add(po)

			Dim pob As New PointF(PictureBox1.Image.Size.Width, y * dy)
			confi.Puntos.Add(pob)

		Next
	End Sub

	Private Sub AgregarPuntosRandomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarPuntosRandomToolStripMenuItem.Click
		Dim alto As Integer = PictureBox1.Image.Size.Height
		Dim ancho As Integer = PictureBox1.Image.Size.Width

		For i = 0 To 10
			Dim x As Integer = Rnd() * ancho
			Dim y As Integer = Rnd() * alto
			Dim pob As New PointF(x, y)
			confi.Puntos.Add(pob)
		Next
	End Sub

	Private Sub ToolStripButton3_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
		CalculoAutomatico()
	End Sub

	Private Sub CalcularSinModificarPivotesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalcularSinModificarPivotesToolStripMenuItem.Click
		Dim ima As New Bitmap(PictureBox1.Image)
		Dim obje As New ImageSingle(ima)
		Dim sali As ConvertirLineas.Resultados
		sali = calculo.Convertir(obje, confi)
		PropertyGrid2.SelectedObject = sali
		PictureBox2.Image = sali.Imagen.GetImg
		PictureBox3.Image = calculo.GenerarLineas(sali)
	End Sub
End Class
