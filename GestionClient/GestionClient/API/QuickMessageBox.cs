using System.Windows.Forms;

namespace GestionClient
{
    /// <summary>
    /// A wrapper for System.Windows.Forms.QuickMessageBox that allows 
    /// showing different MessageBoxes using methods with short parameters.
    /// </summary>
    static class QuickMessageBox
    {
        #region Private-Methods
        private static DialogResult Show(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, API.AppName, buttons, icon,
                MessageBoxDefaultButton.Button1, API.CurrentMessageBoxOptions);
        }
        #endregion

        public static DialogResult ShowInformation(string text)
        {
            return Show(text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowQuestion(string text)
        {
            return Show(text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        public static DialogResult ShowWarning(string text)
        {
            return Show(text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowError(string text)
        {
            return Show(text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
