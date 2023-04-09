Imports System.Drawing.Imaging
''' <summary>
''' Objeto que representa una imagen en formato de punto flotante (para realizar operaciones entre si)
''' </summary>
<Serializable> Public Class ImageSingle
	Public R(,) As Single
	Public G(,) As Single
	Public B(,) As Single
	Public A(,) As Single

	Public maxR As Single
	Public maxG As Single
	Public maxB As Single
	Public maxA As Single

	Property Time As Double

	Public ReadOnly Property Width As Integer
		Get
			Return BackWidth
		End Get
	End Property
	Dim BackWidth As Integer

	Public ReadOnly Property Height As Integer
		Get
			Return BackHeight
		End Get
	End Property
	Dim BackHeight As Integer

	Sub New()

	End Sub


	Sub New(_Width As Integer, _Height As Integer)
		ReDim A(_Width, _Height)
		ReDim R(_Width, _Height)
		ReDim G(_Width, _Height)
		ReDim B(_Width, _Height)
		BackHeight = _Height
		BackWidth = _Width
	End Sub


	''' <summary>
	''' Inicialización con imagen de referencia
	''' </summary>
	''' <param name="Image"></param>
	Public Sub New(Image As Drawing.Bitmap)
		' Lock the bitmap data.
		'Dim sali As New ImageSingle

		Dim backImg As New Bitmap(Image.Width, Image.Height, PixelFormat.Format32bppArgb)

		'Dim a As New Bitmap(Image, PixelFormat.Format32bppArgb)

		Dim cini As Color = backImg.GetPixel(0, 0)

		Dim ncolo As Color = Color.FromArgb(1, 2, 3, 4)


		Using gr As Graphics = Graphics.FromImage(backImg)
			gr.DrawImage(Image, New Drawing.Rectangle(0, 0, Image.Width, Image.Height))
		End Using

		backImg.SetPixel(0, 0, ncolo)
		Dim cpruea As Color = backImg.GetPixel(0, 0)
		LockBitmapF(backImg)


		Dim total As Long = UBound(FPixels)
		Dim i As Long
		Dim x, y As Integer
		x = 0
		y = 0
		Dim ancho As Integer = Image.Width
		Dim alto As Integer = Image.Height
		ReDim A(ancho, alto)
		ReDim R(ancho, alto)
		ReDim G(ancho, alto)
		ReDim B(ancho, alto)

		Dim sa, sr, sg, sb As Integer
		sa = 0
		sr = 0
		sg = 0
		sb = 0

		For i = 0 To 3
			If FPixels(i) = 1 Then
				sa = i
			End If
			If FPixels(i) = 2 Then
				sr = i
			End If
			If FPixels(i) = 3 Then
				sg = i
			End If
			If FPixels(i) = 4 Then
				sb = i
			End If
		Next

		For i = 0 To total - 1
			With Me
				'.A(x, y) = FPixels(i)
				'.R(x, y) = FPixels(i + 1)
				'.G(x, y) = FPixels(i + 2)
				'.B(x, y) = FPixels(i + 3)

				.A(x, y) = FPixels(i + sa)
				.R(x, y) = FPixels(i + sr)
				.G(x, y) = FPixels(i + sg)
				.B(x, y) = FPixels(i + sb)
			End With
			i = i + 3

			x = x + 1
			If x >= ancho Then
				x = 0
				y = y + 1
			End If
		Next

		'corrijo los valores con el dato inicial
		A(0, 0) = cini.A
		R(0, 0) = cini.R
		G(0, 0) = cini.G
		B(0, 0) = cini.B

		BackHeight = alto
		BackWidth = ancho
		CheckMax()
		UnlockBitmapF(backImg)
	End Sub


	''' <summary>
	''' Rutina que permite refrescar los valores máximos del mapa
	''' </summary>
	Public Sub CheckMax()
		Dim mr, mg, mb, ma As Single
		mr = 0
		mg = 0
		mb = 0
		ma = 0

		Dim y, x As Integer
		For y = 0 To Height
			For x = 0 To Width
				If R(x, y) > mr Then
					mr = R(x, y)
				End If
				If G(x, y) > mg Then
					mg = G(x, y)
				End If
				If B(x, y) > mb Then
					mb = B(x, y)
				End If
				If A(x, y) > ma Then
					ma = A(x, y)
				End If
			Next
		Next
		maxA = ma
		maxR = mr
		maxG = mg
		maxB = mb

	End Sub


	''' <summary>
	''' Rutina que genera la imagen reconstruyendose desde los datos de las matrices. 
	''' </summary>
	''' <returns></returns>
	Public Function GetImg() As Bitmap
		Return GetImg(maxA)
	End Function

	''' <summary>
	''' Rutina que fuerza un valor sobre el canal alpha
	''' </summary>
	''' <param name="MaxAlpha"></param>
	''' <returns></returns>
	Public Function GetImg(MaxAlpha As Single) As Bitmap
		Dim backImg As New Bitmap(Width, Height, PixelFormat.Format32bppArgb)

		LockBitmapF(backImg)


		Dim total As Long = UBound(FPixels)
		Dim i As Long
		Dim x, y As Integer
		Dim ancho As Integer = Width
		x = 0
		y = 0
		For i = 0 To total - 3
			With Me
				FPixels(i + 3) = Saturado8Bit(.A(x, y), MaxAlpha)
				FPixels(i + 0) = Saturado8Bit(.B(x, y), maxB) ' blue 'Saturado8Bit(.R(x, y), maxR)
				FPixels(i + 1) = Saturado8Bit(.G(x, y), maxG) 'green 'Saturado8Bit(.G(x, y), maxG)
				FPixels(i + 2) = Saturado8Bit(.R(x, y), maxR) ' red 'Saturado8Bit(.B(x, y), maxB)
			End With

			i = i + 3

			x = x + 1
			If x >= ancho Then
				x = 0
				y = y + 1
			End If
		Next
		UnlockBitmapF(backImg)
		Return (backImg)
	End Function

	Private Function Saturado8Bit(Valor As Single, maximo As Single) As Byte
		Dim avar As Single = (Valor / maximo) * 255
		Dim sali As Byte
		If avar > 255 Then
			sali = 255
		ElseIf avar < 0 Then
			sali = 0
		ElseIf Single.IsNaN(avar) Then
			sali = 0
		Else

			sali = avar
		End If
		Return sali
	End Function


#Region "Descomposicion Imagen"
	'del fondo
	<NonSerialized> Private FRowSize As Integer
	<NonSerialized> Private FPixels() As Byte
	<NonSerialized> Private FBitmap As Imaging.BitmapData


	Private Sub UnlockBitmapF(ByVal bm As Drawing.Bitmap)
		' Copy the data back into the bitmap.
		Dim total_size As Integer = FBitmap.Stride *
			FBitmap.Height
		Runtime.InteropServices.Marshal.Copy(FPixels, 0,
			FBitmap.Scan0, total_size)

		' Unlock the bitmap.
		bm.UnlockBits(FBitmap)

		' Release resources.
		FPixels = Nothing
		FBitmap = Nothing
	End Sub

	Private Sub LockBitmapF(ByVal bm As Bitmap)
		' Lock the bitmap data.
		Dim bounds As System.Drawing.Rectangle = New System.Drawing.Rectangle(
			0, 0, bm.Width, bm.Height)
		FBitmap = bm.LockBits(bounds,
			Imaging.ImageLockMode.ReadWrite,
			Imaging.PixelFormat.Format32bppArgb)
		FRowSize = FBitmap.Stride

		' Allocate room for the data.
		Dim total_size As Integer = FBitmap.Stride * FBitmap.Height
		ReDim FPixels(total_size)

		' Copy the data into the g_PixBytes array.
		Runtime.InteropServices.Marshal.Copy(FBitmap.Scan0, FPixels, 0, total_size)
	End Sub
#End Region


#Region "Operaciones"
	Public Shared Operator +(ByVal lhs As ImageSingle, ByVal rhs As ImageSingle) As ImageSingle
		Dim sali As New ImageSingle(lhs.Width, lhs.Height)
		If lhs.Height = rhs.Height And lhs.Width = rhs.Width Then
			'si las dos imagenes son iguales las sumo

			Dim x, y As Integer
			For y = 0 To lhs.Height
				For x = 0 To lhs.Width
					With sali
						.R(x, y) = lhs.R(x, y) + rhs.R(x, y)
						.G(x, y) = lhs.G(x, y) + rhs.G(x, y)
						.B(x, y) = lhs.B(x, y) + rhs.B(x, y)
						.A(x, y) = lhs.A(x, y) + rhs.A(x, y)
					End With
				Next
			Next

			sali.maxR = rhs.maxR + lhs.maxR
			sali.maxG = rhs.maxG + lhs.maxG
			sali.maxB = rhs.maxB + lhs.maxB
			sali.maxA = rhs.maxA + lhs.maxA
		End If
		Return sali
	End Operator

	Public Shared Operator -(ByVal lhs As ImageSingle, ByVal rhs As ImageSingle) As ImageSingle
		Dim sali As New ImageSingle(lhs.Width, lhs.Height)
		If lhs.Height = rhs.Height And lhs.Width = rhs.Width Then
			'si las dos imagenes son iguales las sumo

			Dim x, y As Integer
			For y = 0 To lhs.Height
				For x = 0 To lhs.Width
					With sali
						.R(x, y) = lhs.R(x, y) - rhs.R(x, y)
						.G(x, y) = lhs.G(x, y) - rhs.G(x, y)
						.B(x, y) = lhs.B(x, y) - rhs.B(x, y)
						.A(x, y) = lhs.A(x, y) - rhs.A(x, y)
					End With
				Next
			Next

			sali.maxR = rhs.maxR - lhs.maxR
			sali.maxG = rhs.maxG - lhs.maxG
			sali.maxB = rhs.maxB - lhs.maxB
			sali.maxA = rhs.maxA - lhs.maxA
		End If
		Return sali
	End Operator


	Public Shared Operator *(ByVal lhs As ImageSingle, ByVal rhs As ImageSingle) As ImageSingle
		Dim sali As New ImageSingle(lhs.Width, lhs.Height)
		If lhs.Height = rhs.Height And lhs.Width = rhs.Width Then
			'si las dos imagenes son iguales las sumo

			Dim x, y As Integer
			For y = 0 To lhs.Height
				For x = 0 To lhs.Width
					With sali
						.R(x, y) = lhs.R(x, y) * rhs.R(x, y)
						.G(x, y) = lhs.G(x, y) * rhs.G(x, y)
						.B(x, y) = lhs.B(x, y) * rhs.B(x, y)
						.A(x, y) = lhs.A(x, y) * rhs.A(x, y)
					End With
				Next
			Next

			sali.maxR = rhs.maxR * lhs.maxR
			sali.maxG = rhs.maxG * lhs.maxG
			sali.maxB = rhs.maxB * lhs.maxB
			sali.maxA = rhs.maxA * lhs.maxA
		End If
		Return sali
	End Operator

	Public Shared Operator /(ByVal lhs As ImageSingle, ByVal rhs As ImageSingle) As ImageSingle
		Dim sali As New ImageSingle(lhs.Width, lhs.Height)
		If lhs.Height = rhs.Height And lhs.Width = rhs.Width Then
			'si las dos imagenes son iguales las sumo

			Dim x, y As Integer
			For y = 0 To lhs.Height
				For x = 0 To lhs.Width
					With sali
						.R(x, y) = lhs.R(x, y) / rhs.R(x, y)
						.G(x, y) = lhs.G(x, y) / rhs.G(x, y)
						.B(x, y) = lhs.B(x, y) / rhs.B(x, y)
						.A(x, y) = lhs.A(x, y) / rhs.A(x, y)
					End With
				Next
			Next

			sali.maxR = rhs.maxR / lhs.maxR
			sali.maxG = rhs.maxG / lhs.maxG
			sali.maxB = rhs.maxB / lhs.maxB
			sali.maxA = rhs.maxA / lhs.maxA
		End If
		Return sali
	End Operator

#End Region



End Class
