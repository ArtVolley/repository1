namespace TestEx2.Module
{
    partial class Generate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Generation = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // Generation
            // 
            this.Generation.Caption = "gnrt";
            this.Generation.Category = "Tools";
            this.Generation.ConfirmationMessage = null;
            this.Generation.Id = "gnrt";
            this.Generation.ToolTip = null;
            this.Generation.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.Generation_Execute);
            // 
            // Generate
            // 
            this.Actions.Add(this.Generation);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction Generation;
    }
}
