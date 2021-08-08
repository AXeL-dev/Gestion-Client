using System.Drawing;
using System.Windows.Forms;
using GestionClient.Properties;

namespace GestionClient
{
    public class DeleteButtonCell : DataGridViewButtonCell
    {
        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, 
            int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, 
            string errorText, DataGridViewCellStyle cellStyle, 
            DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, formattedValue, 
                errorText, cellStyle, advancedBorderStyle, paintParts);
            Rectangle imageCellBounds = new Rectangle();
            imageCellBounds = cellBounds;
            imageCellBounds.X += 4;
            imageCellBounds.Y += 4;
            imageCellBounds.Width -= 9;
            imageCellBounds.Height -= 9;
            graphics.DrawImage(Resources._false, imageCellBounds);
        }
    }

    public class DeleteButtonColumn : DataGridViewButtonColumn
    {
        public DeleteButtonColumn()
        {
            this.CellTemplate = new DeleteButtonCell();
            this.Width = 22;
            this.DefaultCellStyle.Padding = new Padding(1);
            this.Resizable = DataGridViewTriState.False;
        }
    }
}
