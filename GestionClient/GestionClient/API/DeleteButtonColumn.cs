using System.Drawing;
using System.Windows.Forms;

namespace GestionClient
{
    public class DeleteCell : DataGridViewButtonCell
    {
        // méthode Paint
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
            Rectangle imageCellBounds = new Rectangle();
            imageCellBounds = cellBounds;
            imageCellBounds.X += 4;
            imageCellBounds.Y += 4;
            imageCellBounds.Width -= 9;
            imageCellBounds.Height -= 9;
            graphics.DrawImage(GestionClient.Properties.Resources._false, imageCellBounds);
        }
    }

    public class DeleteButtonColumn : DataGridViewButtonColumn
    {
        // constr.
        public DeleteButtonColumn()
        {
            this.CellTemplate = new DeleteCell();
            this.Width = 22;
            this.DefaultCellStyle.Padding = new Padding(1);
            this.Resizable = DataGridViewTriState.False;
        }
    }
}
