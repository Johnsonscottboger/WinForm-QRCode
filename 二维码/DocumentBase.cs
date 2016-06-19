using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 二维码
{
    class DocumentBase:PrintDocument
    {
        public Font font = new Font("Verdana", 10, GraphicsUnit.Point);

        public DialogResult ShowPrintPreviewDialog()
        {
            PrintPreviewDialog dialog = new PrintPreviewDialog();
            dialog.Document = this;
            return dialog.ShowDialog();
        }

        public DialogResult ShowPageSettingsDialog()
        {
            PageSetupDialog dialog = new PageSetupDialog();
            dialog.Document = this;
            return dialog.ShowDialog();
        }
    }
}
