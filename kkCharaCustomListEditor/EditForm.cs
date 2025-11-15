using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kkCharaCustomListEditor
{
    public partial class EditForm : Form
    {
        public string[] EditedValues { get; private set; }

        public EditForm(string[] values)
        {
            InitializeComponent();

            // 初期化
            AddRow("txtID",out txtID, 0);
            AddRow("txtKind", out txtKind,1);
            AddRow("txtPossess", out txtPossess,2);
            AddRow("txtName", out txtName,3);
            AddRow("txtMainManifest", out txtMainManifest,4);
            AddRow("txtMainAB", out txtMainAB,5);
            AddRow("txtMainData", out txtMainData,6);
            AddRow("txtNormalData", out txtNormalData,7);
            AddRow("txtStateType", out txtStateType,8);
            AddRow("txtCoordinate", out txtCoordinate,9);
            AddRow("txtNotBra", out txtNotBra,10);
            AddRow("txtSex", out txtSex,11);
            AddRow("txtOverBodyMaskAB", out txtOverBodyMaskAB,12);
            AddRow("txtOverBodyMask", out txtOverBodyMask,13);
            AddRow("txtOverBraMaskAB", out txtOverBraMaskAB,14);
            AddRow("txtOverBraMask", out txtOverBraMask,15);
            AddRow("txtMainTexAB", out txtMainTexAB,16);
            AddRow("txtMainTex", out txtMainTex,17);
            AddRow("txtColorMaskAB", out txtColorMaskAB,18);
            AddRow("txtColorMaskTex", out txtColorMaskTex,19);
            AddRow("txtMainTex02AB", out txtMainTex02AB,20);
            AddRow("txtMainTex02", out txtMainTex02,21);
            AddRow("txtColorMask02AB", out txtColorMask02AB,22);
            AddRow("txtColorMask02Tex", out txtColorMask02Tex,23);
            AddRow("txtKokanHide", out txtKokanHide,24);
            AddRow("txtThumbAB", out txtThumbAB,25);
            AddRow("txtThumbTex", out txtThumbTex,26);
            // 値をテキストボックスにセット
            txtID.Text = values[0];
            txtKind.Text = values[1];
            txtPossess.Text = values[2];
            txtName.Text = values[3];
            txtMainManifest.Text = values[4];
            txtMainAB.Text = values[5];
            txtMainData.Text = values[6];
            txtNormalData.Text = values[7];
            txtStateType.Text = values[8];
            txtCoordinate.Text = values[9];
            //txtNotBra.Text = values[10];
            txtSex.Text = values[10];
            txtOverBodyMaskAB.Text = values[11];
            txtOverBodyMask.Text = values[12];
            txtOverBraMaskAB.Text = values[13];
            txtOverBraMask.Text = values[14];
            txtMainTexAB.Text = values[15];
            txtMainTex.Text = values[16];
            txtColorMaskAB.Text = values[17];
            txtColorMaskTex.Text = values[18];
            txtMainTex02AB.Text = values[19];
            txtMainTex02.Text = values[20];
            txtColorMask02AB.Text = values[21];
            txtColorMask02Tex.Text = values[22];
            txtKokanHide.Text = values[23];
            txtThumbAB.Text = values[24];
            txtThumbTex.Text = values[25];
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                EditedValues = new string[]
                {
                    txtID.Text,
                    txtKind.Text,
                        txtPossess.Text,
                    txtName.Text,
                    txtMainManifest.Text,
                    txtMainAB.Text,
                    txtMainData.Text,
                    txtNormalData.Text,
                    txtStateType.Text,
                    txtCoordinate.Text,
                    txtNotBra.Text,
                    txtSex.Text,
                    txtOverBodyMaskAB.Text,
                    txtOverBodyMask.Text,
                    txtOverBraMaskAB.Text,
                    txtOverBraMask.Text,
                    txtMainTexAB.Text,
                    txtMainTex.Text,
                    txtColorMaskAB.Text,
                    txtColorMaskTex.Text,
                    txtMainTex02AB.Text,
                    txtMainTex02.Text,
                    txtColorMask02AB.Text,
                    txtColorMask02Tex.Text,
                    txtKokanHide.Text,
                    txtThumbAB.Text,
                    txtThumbTex.Text
                };
            }
            base.OnFormClosing(e);
        }

        /// <summary>
        /// ラベルとテキストボックスを TableLayoutPanel に追加するヘルパー
        /// </summary>
        private void AddRow(string labelText, out System.Windows.Forms.TextBox txt, int rowIndex)
        {
            var lbl = new System.Windows.Forms.Label()
            {
                Text = labelText,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight,
                Dock = System.Windows.Forms.DockStyle.Fill
            };
            txt = new System.Windows.Forms.TextBox()
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Name = "txt" + labelText
            };
            this.tableLayoutPanel1.Controls.Add(lbl, 0, rowIndex);
            this.tableLayoutPanel1.Controls.Add(txt, 1, rowIndex);
        }
    }

}
