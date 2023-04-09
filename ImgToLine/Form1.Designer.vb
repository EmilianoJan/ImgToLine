<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
		Me.TabControl1 = New System.Windows.Forms.TabControl()
		Me.TabPage1 = New System.Windows.Forms.TabPage()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.TabPage2 = New System.Windows.Forms.TabPage()
		Me.PictureBox2 = New System.Windows.Forms.PictureBox()
		Me.TabPage5 = New System.Windows.Forms.TabPage()
		Me.PictureBox3 = New System.Windows.Forms.PictureBox()
		Me.TabPage4 = New System.Windows.Forms.TabPage()
		Me.PropertyGrid2 = New System.Windows.Forms.PropertyGrid()
		Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
		Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripButton2 = New System.Windows.Forms.ToolStripDropDownButton()
		Me.CalcularDeImagenInicialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.CalcularDeBordesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.AutomaticoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
		Me.ToolStripButton6 = New System.Windows.Forms.ToolStripDropDownButton()
		Me.CalcularBordesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.AgregarBordesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.AgregarPuntosEnContornoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.AgregarPuntosRandomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
		Me.CalcularSinModificarPivotesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.TabControl1.SuspendLayout()
		Me.TabPage1.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage2.SuspendLayout()
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage5.SuspendLayout()
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.TabPage4.SuspendLayout()
		Me.ToolStrip1.SuspendLayout()
		Me.SuspendLayout()
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.PropertyGrid1)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
		Me.SplitContainer1.Size = New System.Drawing.Size(800, 425)
		Me.SplitContainer1.SplitterDistance = 206
		Me.SplitContainer1.TabIndex = 4
		'
		'PropertyGrid1
		'
		Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
		Me.PropertyGrid1.Name = "PropertyGrid1"
		Me.PropertyGrid1.Size = New System.Drawing.Size(206, 425)
		Me.PropertyGrid1.TabIndex = 0
		'
		'TabControl1
		'
		Me.TabControl1.Controls.Add(Me.TabPage1)
		Me.TabControl1.Controls.Add(Me.TabPage2)
		Me.TabControl1.Controls.Add(Me.TabPage5)
		Me.TabControl1.Controls.Add(Me.TabPage4)
		Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.TabControl1.Location = New System.Drawing.Point(0, 0)
		Me.TabControl1.Name = "TabControl1"
		Me.TabControl1.SelectedIndex = 0
		Me.TabControl1.Size = New System.Drawing.Size(590, 425)
		Me.TabControl1.TabIndex = 1
		'
		'TabPage1
		'
		Me.TabPage1.Controls.Add(Me.PictureBox1)
		Me.TabPage1.Location = New System.Drawing.Point(4, 22)
		Me.TabPage1.Name = "TabPage1"
		Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage1.Size = New System.Drawing.Size(582, 399)
		Me.TabPage1.TabIndex = 0
		Me.TabPage1.Text = "Original"
		Me.TabPage1.UseVisualStyleBackColor = True
		'
		'PictureBox1
		'
		Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(576, 393)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = False
		'
		'TabPage2
		'
		Me.TabPage2.Controls.Add(Me.PictureBox2)
		Me.TabPage2.Location = New System.Drawing.Point(4, 22)
		Me.TabPage2.Name = "TabPage2"
		Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage2.Size = New System.Drawing.Size(582, 399)
		Me.TabPage2.TabIndex = 1
		Me.TabPage2.Text = "Remasterizada"
		Me.TabPage2.UseVisualStyleBackColor = True
		'
		'PictureBox2
		'
		Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PictureBox2.Location = New System.Drawing.Point(3, 3)
		Me.PictureBox2.Name = "PictureBox2"
		Me.PictureBox2.Size = New System.Drawing.Size(576, 393)
		Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox2.TabIndex = 0
		Me.PictureBox2.TabStop = False
		'
		'TabPage5
		'
		Me.TabPage5.Controls.Add(Me.PictureBox3)
		Me.TabPage5.Location = New System.Drawing.Point(4, 22)
		Me.TabPage5.Name = "TabPage5"
		Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage5.Size = New System.Drawing.Size(582, 399)
		Me.TabPage5.TabIndex = 4
		Me.TabPage5.Text = "Imagen hilos"
		Me.TabPage5.UseVisualStyleBackColor = True
		'
		'PictureBox3
		'
		Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PictureBox3.Location = New System.Drawing.Point(3, 3)
		Me.PictureBox3.Name = "PictureBox3"
		Me.PictureBox3.Size = New System.Drawing.Size(576, 393)
		Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox3.TabIndex = 0
		Me.PictureBox3.TabStop = False
		'
		'TabPage4
		'
		Me.TabPage4.Controls.Add(Me.PropertyGrid2)
		Me.TabPage4.Location = New System.Drawing.Point(4, 22)
		Me.TabPage4.Name = "TabPage4"
		Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
		Me.TabPage4.Size = New System.Drawing.Size(582, 399)
		Me.TabPage4.TabIndex = 3
		Me.TabPage4.Text = "Resultados"
		Me.TabPage4.UseVisualStyleBackColor = True
		'
		'PropertyGrid2
		'
		Me.PropertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.PropertyGrid2.Location = New System.Drawing.Point(3, 3)
		Me.PropertyGrid2.Name = "PropertyGrid2"
		Me.PropertyGrid2.Size = New System.Drawing.Size(576, 393)
		Me.PropertyGrid2.TabIndex = 0
		'
		'ToolStrip1
		'
		Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripButton5, Me.ToolStripButton6})
		Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
		Me.ToolStrip1.Name = "ToolStrip1"
		Me.ToolStrip1.Size = New System.Drawing.Size(800, 25)
		Me.ToolStrip1.TabIndex = 3
		Me.ToolStrip1.Text = "ToolStrip1"
		'
		'ToolStripButton1
		'
		Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
		Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButton1.Name = "ToolStripButton1"
		Me.ToolStripButton1.Size = New System.Drawing.Size(53, 22)
		Me.ToolStripButton1.Text = "Abrir"
		'
		'ToolStripButton2
		'
		Me.ToolStripButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalcularDeImagenInicialToolStripMenuItem, Me.CalcularDeBordesToolStripMenuItem, Me.AutomaticoToolStripMenuItem, Me.CalcularSinModificarPivotesToolStripMenuItem})
		Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
		Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButton2.Name = "ToolStripButton2"
		Me.ToolStripButton2.Size = New System.Drawing.Size(137, 22)
		Me.ToolStripButton2.Text = "Calcular (variantes)"
		'
		'CalcularDeImagenInicialToolStripMenuItem
		'
		Me.CalcularDeImagenInicialToolStripMenuItem.Name = "CalcularDeImagenInicialToolStripMenuItem"
		Me.CalcularDeImagenInicialToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
		Me.CalcularDeImagenInicialToolStripMenuItem.Text = "Calcular de imagen inicial"
		'
		'CalcularDeBordesToolStripMenuItem
		'
		Me.CalcularDeBordesToolStripMenuItem.Name = "CalcularDeBordesToolStripMenuItem"
		Me.CalcularDeBordesToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
		Me.CalcularDeBordesToolStripMenuItem.Text = "Calcular de bordes"
		'
		'AutomaticoToolStripMenuItem
		'
		Me.AutomaticoToolStripMenuItem.Name = "AutomaticoToolStripMenuItem"
		Me.AutomaticoToolStripMenuItem.Size = New System.Drawing.Size(210, 22)
		Me.AutomaticoToolStripMenuItem.Text = "Automatico"
		'
		'ToolStripButton5
		'
		Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
		Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButton5.Name = "ToolStripButton5"
		Me.ToolStripButton5.Size = New System.Drawing.Size(112, 22)
		Me.ToolStripButton5.Text = "Guardar imagen"
		'
		'ToolStripButton6
		'
		Me.ToolStripButton6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalcularBordesToolStripMenuItem, Me.AgregarBordesToolStripMenuItem, Me.AgregarPuntosEnContornoToolStripMenuItem, Me.AgregarPuntosRandomToolStripMenuItem})
		Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
		Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButton6.Name = "ToolStripButton6"
		Me.ToolStripButton6.Size = New System.Drawing.Size(109, 22)
		Me.ToolStripButton6.Text = "Puntos pivote"
		'
		'CalcularBordesToolStripMenuItem
		'
		Me.CalcularBordesToolStripMenuItem.Name = "CalcularBordesToolStripMenuItem"
		Me.CalcularBordesToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
		Me.CalcularBordesToolStripMenuItem.Text = "Calcular Bordes"
		'
		'AgregarBordesToolStripMenuItem
		'
		Me.AgregarBordesToolStripMenuItem.Name = "AgregarBordesToolStripMenuItem"
		Me.AgregarBordesToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
		Me.AgregarBordesToolStripMenuItem.Text = "Agregar bordes "
		'
		'AgregarPuntosEnContornoToolStripMenuItem
		'
		Me.AgregarPuntosEnContornoToolStripMenuItem.Name = "AgregarPuntosEnContornoToolStripMenuItem"
		Me.AgregarPuntosEnContornoToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
		Me.AgregarPuntosEnContornoToolStripMenuItem.Text = "Agregar puntos en contorno"
		'
		'AgregarPuntosRandomToolStripMenuItem
		'
		Me.AgregarPuntosRandomToolStripMenuItem.Name = "AgregarPuntosRandomToolStripMenuItem"
		Me.AgregarPuntosRandomToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
		Me.AgregarPuntosRandomToolStripMenuItem.Text = "Agregar puntos random"
		'
		'ToolStripButton3
		'
		Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
		Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.ToolStripButton3.Name = "ToolStripButton3"
		Me.ToolStripButton3.Size = New System.Drawing.Size(136, 22)
		Me.ToolStripButton3.Text = "Calcular Automático"
		'
		'CalcularSinModificarPivotesToolStripMenuItem
		'
		Me.CalcularSinModificarPivotesToolStripMenuItem.Name = "CalcularSinModificarPivotesToolStripMenuItem"
		Me.CalcularSinModificarPivotesToolStripMenuItem.Size = New System.Drawing.Size(230, 22)
		Me.CalcularSinModificarPivotesToolStripMenuItem.Text = "Calcular sin modificar pivotes"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.ToolStrip1)
		Me.Name = "Form1"
		Me.Text = "Img To Line"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.TabControl1.ResumeLayout(False)
		Me.TabPage1.ResumeLayout(False)
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage2.ResumeLayout(False)
		CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage5.ResumeLayout(False)
		CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.TabPage4.ResumeLayout(False)
		Me.ToolStrip1.ResumeLayout(False)
		Me.ToolStrip1.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents PropertyGrid1 As PropertyGrid
	Friend WithEvents TabControl1 As TabControl
	Friend WithEvents TabPage1 As TabPage
	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents TabPage2 As TabPage
	Friend WithEvents PictureBox2 As PictureBox
	Friend WithEvents TabPage5 As TabPage
	Friend WithEvents PictureBox3 As PictureBox
	Friend WithEvents TabPage4 As TabPage
	Friend WithEvents PropertyGrid2 As PropertyGrid
	Friend WithEvents ToolStrip1 As ToolStrip
	Friend WithEvents ToolStripButton1 As ToolStripButton
	Friend WithEvents ToolStripButton2 As ToolStripDropDownButton
	Friend WithEvents CalcularDeImagenInicialToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents CalcularDeBordesToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents AutomaticoToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ToolStripButton5 As ToolStripButton
	Friend WithEvents ToolStripButton6 As ToolStripDropDownButton
	Friend WithEvents CalcularBordesToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents AgregarBordesToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents AgregarPuntosEnContornoToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents AgregarPuntosRandomToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ToolStripButton3 As ToolStripButton
	Friend WithEvents CalcularSinModificarPivotesToolStripMenuItem As ToolStripMenuItem
End Class
