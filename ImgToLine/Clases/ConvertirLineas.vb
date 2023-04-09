Imports Accord.Math
Imports AForge.Imaging
''' <summary>
''' Clase que mediante una imagen y unas megurtaciones extrae un trazado de direcciones
''' </summary>
Public Class ConvertirLineas



	Public Function Convertir(Imagen As ImageSingle, meg As Configuracion) As Resultados

		Dim sali As New Resultados
		With sali
			.meg = meg
			.Imagen = Imagen
		End With

		Dim i As Integer
		Dim Pactual As PointF = meg.Puntos(0)
		For i = 0 To meg.Repeticiones
			Dim mejorV As Double = Double.PositiveInfinity
			Dim mejorP As PointF = New PointF(0, 0)
			For Each punto In meg.Puntos
				Dim avar As Double
				avar = CalcularSombraC(Imagen, Pactual, punto)
				'If punto.X >= Pactual.X Then
				'	avar = CalcularSombraC(Imagen, Pactual, punto)
				'Else
				'	avar = CalcularSombraC(Imagen, punto, Pactual)
				'End If
				If avar < mejorV Then
					If Pactual.X <> punto.X Or Pactual.Y <> punto.Y Then
						mejorV = avar
						mejorP = punto
					End If
				End If
			Next

			'ya tenemos el mejor punto. Seguimos
			sali.Trayectos.Add(mejorP)
			RestarC(Imagen, mejorP, Pactual, meg.RestaValor)
			'If mejorP.X <= Pactual.X Then
			'	RestarC(Imagen, mejorP, Pactual, meg.RestaValor)
			'Else
			'	RestarC(Imagen, Pactual, mejorP, meg.RestaValor)
			'End If
			Pactual = mejorP
		Next
		Return sali
	End Function

	''' <summary>
	''' rutina que genera la imagen final usando lineas
	''' </summary>
	''' <param name="Resu"></param>
	''' <returns></returns>
	Public Function GenerarLineas(Resu As Resultados) As Bitmap
		Dim sali As New Bitmap(Resu.Imagen.Width, Resu.Imagen.Height)

		Dim g As Graphics = Graphics.FromImage(sali)

		Dim pe As New Pen(Color.FromArgb(100, 0, 0, 0))
		Dim pe2 As New SolidBrush(Color.FromArgb(255, 255, 255, 255))

		Dim rec As New Rectangle(0, 0, Resu.Imagen.Width, Resu.Imagen.Height)
		g.FillRectangle(pe2, rec)

		Dim i As Integer
		For i = 1 To Resu.Trayectos.Count - 1

			g.DrawLine(pe, Resu.Trayectos(i - 1), Resu.Trayectos(i))
		Next

		Return sali
	End Function

	''' <summary>
	''' Pactx menor Pfinalx
	''' </summary>
	''' <param name="Ima"></param>
	''' <param name="PActual"></param>
	''' <param name="PFinal"></param>
	''' <returns></returns>
	Private Function CalcularSombra(Ima As ImageSingle, PActual As PointF, PFinal As PointF) As Double
		Dim dx, dy, D, y As Double
		dx = PFinal.X - PActual.X
		dy = PFinal.Y - PActual.Y
		D = 2 * dy - dx
		y = PActual.Y
		Dim x0, x1 As Integer
		x0 = PActual.X
		x1 = PFinal.X
		Dim x As Integer
		Dim sali As Double = 0
		For x = x0 To x1
			'El punto es x,y
			sali = sali + ((Ima.R(x, y) + Ima.G(x, y) + Ima.B(x, y)) / 3) * (Ima.A(x, y) / 255)
			If D > 0 Then
				y = y + 1
				D = D - 2 * dx
			End If
			D = D + 2 * dy
		Next
		Return sali
	End Function

	Private Sub Restar(Ima As ImageSingle, PActual As PointF, PFinal As PointF, Valor As Single)
		Dim dx, dy, D, y As Double
		dx = PFinal.X - PActual.X
		dy = PFinal.Y - PActual.Y
		D = 2 * dy - dx
		y = PActual.Y
		Dim x0, x1 As Integer
		x0 = PActual.X
		x1 = PFinal.X
		Dim x As Integer
		Dim sali As Double = 0
		For x = x0 To x1
			'El punto es x,y
			Ima.R(x, y) = Ima.R(x, y) + Valor
			Ima.G(x, y) = Ima.G(x, y) + Valor
			Ima.B(x, y) = Ima.B(x, y) + Valor

			If Ima.R(x, y) > 255 Then
				Ima.R(x, y) = 255
			End If

			If Ima.G(x, y) > 255 Then
				Ima.G(x, y) = 255
			End If

			If Ima.B(x, y) > 255 Then
				Ima.B(x, y) = 255
			End If


			If D > 0 Then
				y = y + 1
				D = D - 2 * dx
			End If
			D = D + 2 * dy
		Next
	End Sub


	Private Sub RestarB(Ima As ImageSingle, Inicial As PointF, Final As PointF, Valor As Single)
		Dim x = CInt(Inicial.X)
		Dim y = CInt(Inicial.Y)
		Dim x2 = CInt(Final.X)
		Dim y2 = CInt(Final.Y)
		Dim dx = Math.Abs(x2 - x)
		Dim dy = Math.Abs(y2 - y)
		Dim sx = If(x < x2, 1, -1)
		Dim sy = If(y < y2, 1, -1)
		Dim err = dx - dy
		'aca tengo el punto x,y

		Ima.R(x, y) = Ima.R(x, y) + Valor
		Ima.G(x, y) = Ima.G(x, y) + Valor
		Ima.B(x, y) = Ima.B(x, y) + Valor

		If Ima.R(x, y) > 255 Then
			Ima.R(x, y) = 255
		End If

		If Ima.G(x, y) > 255 Then
			Ima.G(x, y) = 255
		End If

		If Ima.B(x, y) > 255 Then
			Ima.B(x, y) = 255
		End If

		While Not (x = x2 AndAlso y = y2)

			' var e2 = err << 1;
			Dim e2 As Double = Double.Epsilon * 10
			If e2 > -dy Then
				err -= dy
				x += sx
			End If

			If e2 < dx Then
				err += dx
				y += sy
			End If
			If (x >= 0) And (x <= Ima.Width) And (y >= 0) And (y <= Ima.Height) Then
				Ima.R(x, y) = Ima.R(x, y) + Valor
				Ima.G(x, y) = Ima.G(x, y) + Valor
				Ima.B(x, y) = Ima.B(x, y) + Valor

				If Ima.R(x, y) > 255 Then
					Ima.R(x, y) = 255
				End If

				If Ima.G(x, y) > 255 Then
					Ima.G(x, y) = 255
				End If

				If Ima.B(x, y) > 255 Then
					Ima.B(x, y) = 255
				End If
			End If
			'aca tengo el punto x,y
			'drawAction.Invoke(x, y)
		End While
	End Sub


	Private Function RestarC(Ima As ImageSingle, Inicial As PointF, Final As PointF, Valor As Single) As Double
		Dim x0 = CInt(Inicial.X)
		Dim y0 = CInt(Inicial.Y)
		Dim x1 = CInt(Final.X)
		Dim y1 = CInt(Final.Y)
		Dim dx As Integer = Math.Abs(x1 - x0)
		Dim dy As Integer = -Math.Abs(y1 - y0)
		Dim sx As Integer = If(x0 < x1, 1, -1)
		Dim sy As Integer = If(y0 < y1, 1, -1)
		Dim err As Integer = dx + dy

		Dim sali As Double = 0
		Dim e2 As Double
		While True

			'punto xy
			If (x0 >= 0) And (x0 <= Ima.Width) And (y0 >= 0) And (y0 <= Ima.Height) Then
				Ima.R(x0, y0) = Ima.R(x0, y0) + Valor
				Ima.G(x0, y0) = Ima.G(x0, y0) + Valor
				Ima.B(x0, y0) = Ima.B(x0, y0) + Valor

				If Ima.R(x0, y0) > 255 Then
					Ima.R(x0, y0) = 255
				End If

				If Ima.G(x0, y0) > 255 Then
					Ima.G(x0, y0) = 255
				End If

				If Ima.B(x0, y0) > 255 Then
					Ima.B(x0, y0) = 255
				End If
			End If

			If x0 = x1 And y0 = y1 Then
				Exit While
			End If

			' var e2 = err << 1;
			e2 = 2 * err
			If e2 >= dy Then
				If x0 = x1 Then
					Exit While
				End If
				err += dy
				x0 += sx
			End If

			If e2 <= dx Then
				If y0 = y1 Then
					Exit While
				End If
				err += dx
				y0 += sy
			End If
		End While

		Return sali
	End Function



	Private Function CalcularSombraB(Ima As ImageSingle, Inicial As PointF, Final As PointF) As Double
		Dim x = CInt(Inicial.X)
		Dim y = CInt(Inicial.Y)
		Dim x2 = CInt(Final.X)
		Dim y2 = CInt(Final.Y)
		Dim dx As Integer = Math.Abs(x2 - x)
		Dim dy As Integer = Math.Abs(y2 - y)
		Dim sx As Integer = If(x < x2, 1, -1)
		Dim sy As Integer = If(y < y2, 1, -1)
		Dim err As Integer = dx - dy

		Dim sali As Double = 0
		sali = sali + ((Ima.R(x, y) + Ima.G(x, y) + Ima.B(x, y)) / 3) * (Ima.A(x, y) / 255)
		'aca tengo el punto x,y
		While Not (x = x2 AndAlso y = y2)

			' var e2 = err << 1;
			Dim e2 As Double = Double.Epsilon * 10
			If e2 > -dy Then
				err -= dy
				x += sx
			End If

			If e2 < dx Then
				err += dx
				y += sy
			End If

			If (x >= 0) And (x <= Ima.Width) And (y >= 0) And (y <= Ima.Height) Then
				sali = sali + ((Ima.R(x, y) + Ima.G(x, y) + Ima.B(x, y)) / 3) * (Ima.A(x, y) / 255)
			End If
			'aca tengo el punto x,y
		End While

		Return sali
	End Function


	Private Function CalcularSombraC(Ima As ImageSingle, Inicial As PointF, Final As PointF) As Double
		Dim x0 = CInt(Inicial.X)
		Dim y0 = CInt(Inicial.Y)
		Dim x1 = CInt(Final.X)
		Dim y1 = CInt(Final.Y)
		Dim dx As Integer = Math.Abs(x1 - x0)
		Dim dy As Integer = -Math.Abs(y1 - y0)
		Dim sx As Integer = If(x0 < x1, 1, -1)
		Dim sy As Integer = If(y0 < y1, 1, -1)
		Dim err As Integer = dx + dy

		Dim sali As Double = 0
		Dim cuentastot As Long = 0
		Dim e2 As Double
		While True

			'punto xy
			If (x0 >= 0) And (x0 <= Ima.Width) And (y0 >= 0) And (y0 <= Ima.Height) Then
				Dim avar As Single = ((Ima.R(x0, y0) + Ima.G(x0, y0) + Ima.B(x0, y0)) / 3) '* (Ima.A(x0, y0) / 255)
				'If avar > 128 Then
				'	sali = sali + 1
				'Else
				'	'sali = sali - 1
				'End If
				sali = sali + avar
				cuentastot = cuentastot + 1
			End If

			If x0 = x1 And y0 = y1 Then
				Exit While
			End If

			' var e2 = err << 1;
			e2 = 2 * err
			If e2 >= dy Then
				If x0 = x1 Then
					Exit While
				End If
				err += dy
				x0 += sx
			End If

			If e2 <= dx Then
				If y0 = y1 Then
					Exit While
				End If
				err += dx
				y0 += sy
			End If
		End While

		Return (sali / cuentastot)
	End Function


	Public Sub DrawLineR(ByVal Inicial As PointF, ByVal Final As PointF)
		Dim x = CInt(Inicial.X)
		Dim y = CInt(Inicial.Y)
		Dim x2 = CInt(Final.X)
		Dim y2 = CInt(Final.Y)
		Dim dx = Math.Abs(x2 - x)
		Dim dy = Math.Abs(y2 - y)
		Dim sx = If(x < x2, 1, -1)
		Dim sy = If(y < y2, 1, -1)
		Dim err = dx - dy
		'drawAction.Invoke(x, y)
		'aca tengo el punto x,y
		While Not (x = x2 AndAlso y = y2)

			' var e2 = err << 1;
			Dim e2 As Double = Double.Epsilon * 10
			If e2 > -dy Then
				err -= dy
				x += sx
			End If

			If e2 < dx Then
				err += dx
				y += sy
			End If

			'aca tengo el punto x,y
			'drawAction.Invoke(x, y)
		End While
	End Sub



	''' <summary>
	''' Contiene el listado de trayectos
	''' </summary>
	Public Class Resultados

		Public Property Trayectos As New List(Of System.Drawing.PointF)

		Public Property meg As Configuracion

		Public Property Imagen As ImageSingle


	End Class



	''' <summary>
	''' clase encargada de las meguraciones de la transformación
	''' </summary>
	Public Class Configuracion

		Public Property Ancho As Single

		Public Property Alto As Single


		Public Property Repeticiones As Integer

		Public Property Puntos As New List(Of System.Drawing.PointF)


		Public Property RestaValor As Single

		''' <summary>
		''' Rutina que carga los puntos en el contorno de la imagen
		''' </summary>
		''' <param name="Cantidad"></param>
		''' <param name="ImagenRef"></param>
		Public Sub CargarPuntosMarco(Cantidad As Integer, ImagenRef As Bitmap)
			'genera los puntos
			Me.Alto = ImagenRef.Size.Height
			Me.Ancho = ImagenRef.Size.Width

			'genero 5 X 5  puntos (para la prueba)

			Dim x, y As Integer
			Dim dx, dy As Integer

			Dim puntoslado As Integer = Cantidad

			dx = ImagenRef.Size.Width / puntoslado
			dy = ImagenRef.Size.Height / puntoslado

			Me.Puntos.Clear()
			For x = 0 To (puntoslado - 1)
				Dim po As New PointF(x * dx, 0)
				Me.Puntos.Add(po)

				Dim pob As New PointF(x * dx, ImagenRef.Size.Height)
				Me.Puntos.Add(pob)
			Next
			For y = 0 To (puntoslado - 1)
				Dim po As New PointF(0, y * dy)
				Me.Puntos.Add(po)

				Dim pob As New PointF(ImagenRef.Size.Width, y * dy)
				Me.Puntos.Add(pob)
			Next
		End Sub

		''' <summary>
		''' Rutina que carga puntos teniendo en cuenta los bordes que tiene la imagen
		''' </summary>
		''' <param name="Cantidad"></param>
		''' <param name="ImagenRef"></param>
		Public Sub CargaPuntosPorContorno(Cantidad As Integer, ImagenRef As Bitmap)
			Dim mcd As New MoravecCornersDetector()
			Dim bordes As List(Of AForge.IntPoint) = mcd.ProcessImage(ImagenRef)

			Dim max As Integer = bordes.Count

			Dim i As Integer
			Dim dic As New Dictionary(Of String, AForge.IntPoint)
			For i = 0 To Cantidad
				Dim avar As Integer = Rnd() * max

				If dic.ContainsKey(avar.ToString) = False Then
					Dim po As New PointF(bordes(avar).X, bordes(avar).Y)
					Me.Puntos.Add(po)
				Else
					i = i - 1
				End If

			Next
		End Sub



	End Class
End Class
