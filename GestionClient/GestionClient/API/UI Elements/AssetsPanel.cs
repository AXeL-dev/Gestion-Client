using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GestionClient.Properties;

namespace GestionClient
{
    class ImageAssetsPanel : TableLayoutPanel
    {
        [Browsable(true)]
        [Category("Image Assets")]
        public event EventHandler ImageAssetClick;
        [Browsable(true)]
        [Category("Image Assets")]
        public event EventHandler ImageAssetDoubleClick;

        private readonly List<ImageAsset> _imageAssets;

        public ImageAsset SelectedImageAsset { get; private set; }
        public bool IsEmpty { get { return _imageAssets.Count == 0; } }

        public ImageAssetsPanel()
            : base()
        {
            this._imageAssets = new List<ImageAsset>();
            this.ColumnCount = 1;
        }

        #region Private-Methods
        private void AddPictureBox(ImageAsset asset)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.InitialImage = Resources.load;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Cursor = Cursors.Hand;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Name = asset.GUID.ToString();
            pictureBox.Tag = asset.ID;
            pictureBox.Image = asset.Image;
            pictureBox.Click += pictureBox_Click;
            pictureBox.DoubleClick += pictureBox_DoubleClick;
            this.Controls.Add(pictureBox, this._imageAssets.Count - 1, 0);
        }

        private void RemovePictureBox(ImageAsset asset)
        {
            this.Controls.RemoveByKey(asset.GUID.ToString());
        }

        private void UpdateLayout()
        {
            this.ColumnCount = this._imageAssets.Count;
            var columnStyle = new ColumnStyle(SizeType.Percent, 100f / this._imageAssets.Count);
            if (this.ColumnStyles.Count > 0)
            {
                this.ColumnStyles[0].SizeType = columnStyle.SizeType;
                this.ColumnStyles[0].Width = columnStyle.Width;
            }
            else
            {
                this.ColumnStyles.Add(columnStyle);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            foreach (PictureBox pictureBox in this.Controls)
            {
                pictureBox.BackColor = SystemColors.Control;
                pictureBox.Padding = new Padding(0);
            }
            PictureBox clickedPictureBox = (PictureBox)sender;
            clickedPictureBox.BackColor = SystemColors.Highlight;
            clickedPictureBox.Padding = new Padding(3);
            int id = (int)clickedPictureBox.Tag;
            this.SelectedImageAsset = _imageAssets.Find(imgAsset => imgAsset.ID == id);
            if (this.ImageAssetClick != null)
            {
                this.ImageAssetClick(this.SelectedImageAsset, EventArgs.Empty);
            }
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;
            int id = (int)clickedPictureBox.Tag;
            this.SelectedImageAsset = _imageAssets.Find(imgAsset => imgAsset.ID == id);
            if (this.ImageAssetDoubleClick != null)
            {
                this.ImageAssetDoubleClick(this.SelectedImageAsset, EventArgs.Empty);
            }
        }
        #endregion

        public void AddImageAsset(ImageAsset asset)
        {
            _imageAssets.Add(asset);
            AddPictureBox(asset);
            UpdateLayout();
        }

        public void AddImageAssetsRange(params ImageAsset[] assets)
        {
            foreach (ImageAsset asset in assets)
            {
                _imageAssets.Add(asset);
                AddPictureBox(asset);
            }
            UpdateLayout();
        }

        public void RemoveImageAsset(ImageAsset imageAsset)
        {
            _imageAssets.Remove(imageAsset);
            RemovePictureBox(imageAsset);
            UpdateLayout();
        }

        public void RemoveImageAsset(int id)
        {
            ImageAsset imageAsset = _imageAssets.Find(asset => asset.ID == id);
            this.RemoveImageAsset(imageAsset);
        }

        public void RemoveSelectedImageAsset()
        {
            this.RemoveImageAsset(this.SelectedImageAsset);
        }

        public void Clear()
        {
            this.Controls.Clear();
            this.ColumnStyles.Clear();
            this._imageAssets.Clear();
        }
    }
}
