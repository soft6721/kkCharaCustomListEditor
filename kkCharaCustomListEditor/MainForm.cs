using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace kkCharaCustomListEditor
{
    public partial class MainForm : Form
    {
        private string[] headers;
        private List<CategoryItem> categories;

        public MainForm()
        {
            InitializeComponent();
            InitializeCategories();
            dataGridView1.ReadOnly = true;
        }

        private void InitializeCategories()
        {
            categories = new List<CategoryItem>
            {
                new CategoryItem { Name = "unsigned:000", Number = 000 },
                new CategoryItem { Name = "top:105", Number = 105 },
                new CategoryItem { Name = "bottom:106", Number = 106 },
                new CategoryItem { Name = "bra:107", Number = 107 },
                new CategoryItem { Name = "shorts:108", Number = 108 },
                new CategoryItem { Name = "gloves:109", Number = 109 },
                new CategoryItem { Name = "panst:110", Number = 110 },
                new CategoryItem { Name = "socks:111", Number = 111 },
                new CategoryItem { Name = "shoes:112", Number = 112 },
                new CategoryItem { Name = "ao_head:122", Number = 122 },
                new CategoryItem { Name = "ao_waist:126", Number = 126 },
                new CategoryItem { Name = "ao_hand:129", Number = 129 },
                new CategoryItem { Name = "unknown1:210", Number = 210 }
            };

            // コンボボックスにバインド
            cmbCategoryId.DataSource = categories;
            cmbCategoryId.DisplayMember = "Name";   // 表示はカテゴリ名
            cmbCategoryId.ValueMember = "Number";   // 値はカテゴリ番号
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog { Filter = "CSVファイル|*.csv" };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var lines = File.ReadAllLines(ofd.FileName);

                    // 1行目: カテゴリ番号 → ComboBox選択
                    var categoryNumberStr = lines[0].Replace(",", "");
                    if (int.TryParse(categoryNumberStr, out int categoryNumber))
                    {
                        var match = categories.FirstOrDefault(c => c.Number == categoryNumber);
                        if (match != null)
                            cmbCategoryId.SelectedItem = match;
                    }

                    // 2行目: 不明数値
                    txtUnknownNumber.Text = lines[1].Replace(",", "");

                    // 3行目: 不明文字列
                    txtUnknownString.Text = lines[2].Replace(",", "");

                    // 4行目: カラム名
                    headers = lines[3].Split(',');

                    // DataGridView初期化
                    dataGridView1.Columns.Clear();
                    foreach (var h in headers)
                    {
                        dataGridView1.Columns.Add(h, h);
                    }

                    // 5行目以降をデータとして追加
                    dataGridView1.Rows.Clear();
                    for (int i = 4; i < lines.Length; i++)
                    {
                        var row = lines[i].Split(',');
                        dataGridView1.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"CSVの読み込みに失敗しました: {ex.Message}",
                    "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog { Filter = "CSVファイル|*.csv" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var sw = new StreamWriter(sfd.FileName))
                {
                    // メタ情報を書き出し
                    // ComboBoxの選択値（カテゴリ番号）を保存
                    if (cmbCategoryId.SelectedValue != null)
                        sw.WriteLine(cmbCategoryId.SelectedValue.ToString());
                    else
                        sw.WriteLine("");

                    sw.WriteLine(txtUnknownNumber.Text);
                    sw.WriteLine(txtUnknownString.Text);

                    // カラム名
                    sw.WriteLine(string.Join(",", headers));

                    // データ行
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var values = row.Cells.Cast<DataGridViewCell>()
                                .Select(c => c.Value?.ToString() ?? "");
                            sw.WriteLine(string.Join(",", values));
                        }
                    }
                }
            }
        }

        //private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && !dataGridView1.Rows[e.RowIndex].IsNewRow)
        //    {
        //        // 選択行の値を取得
        //        var row = dataGridView1.Rows[e.RowIndex];
        //        var values = row.Cells.Cast<DataGridViewCell>()
        //            .Select(c => c.Value?.ToString() ?? "")
        //            .ToArray();

        //        // 編集フォームを開く
        //        var editForm = new EditForm(values);
        //        if (editForm.ShowDialog() == DialogResult.OK)
        //        {
        //            // OKなら反映
        //            for (int i = 0; i < headers.Length; i++)
        //            {
        //                row.Cells[i].Value = editForm.EditedValues[i];
        //            }
        //        }
        //        // キャンセルなら何もしない
        //    }
        //}

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            // 「新しい行」プレースホルダーをダブルクリックした場合は実体化して編集
            if (row.IsNewRow)
            {
                // 新しい空行を実体化
                int newIndex = dataGridView1.Rows.Add();
                row = dataGridView1.Rows[newIndex];

                // 空の値配列を作成（列数ぶん）
                var emptyValues = new string[headers?.Length ?? dataGridView1.ColumnCount];
                for (int i = 0; i < emptyValues.Length; i++) emptyValues[i] = "";

                var editForm = new EditForm(emptyValues);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < (headers?.Length ?? dataGridView1.ColumnCount); i++)
                    {
                        row.Cells[i].Value = editForm.EditedValues[i];
                    }
                }
                else
                {
                    // キャンセルなら追加した空行を削除
                    dataGridView1.Rows.RemoveAt(newIndex);
                }
                return;
            }

            // 既存行の場合はその値を使って編集
            var values = row.Cells.Cast<DataGridViewCell>()
                .Select(c => c.Value?.ToString() ?? "")
                .ToArray();

            var form = new EditForm(values);
            if (form.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < (headers?.Length ?? dataGridView1.ColumnCount); i++)
                {
                    row.Cells[i].Value = form.EditedValues[i];
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            // 空行を追加
            dataGridView1.Rows.Add();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

}
