
Imports System.Linq
Namespace DrawingCSharp
	Public Class Program
		Private Shared drawing1 As IShape() = New IShape() {New Circle(3), New Circle(4), New Rectangle(2, 7), New Circle(10), New EquilateralTriangle(8)}

		Private Shared Sub GrowAll(shapes As IShape(), percent As Integer)
            ' iterate (loop) over array and delegate to equivalent method on each
            For Each shape As IShape In shapes
                shape.GrowBy(percent)
            Next
        End Sub

		Private Shared Sub RotateAllRotatable(shapes As IShape(), degrees As Integer)
            'You will need to add 'using System.Linq;' at the top of the file
            For Each rotatableObject As IRotatable In shapes.OfType(Of IRotatable)()
                rotatableObject.RotateBy(degrees)
            Next
        End Sub

		Private Shared Sub SummariseAll(shapes As IShape())
            For Each shape As IShape In shapes
                Console.WriteLine(shape.Summary())
            Next
        End Sub

		' Main program here...
		Public Shared Sub Main()
            Console.WriteLine("Polymorphism in VB")
            SummariseAll(drawing1)
			GrowAll(drawing1, 50)
			Console.WriteLine()
			Console.WriteLine("After growing all by 50%:")
			SummariseAll(drawing1)

			RotateAllRotatable(drawing1, 90)
			Console.WriteLine("After rotating all by 90:")
			SummariseAll(drawing1)



			'To keep console open
			Console.WriteLine("Press any key to continue . . .")
			Console.ReadKey()
		End Sub
	End Class
End Namespace

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
