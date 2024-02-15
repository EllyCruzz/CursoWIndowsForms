using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursoWindowsForms
{
    public partial class Frm_Agencia : Form
    {
        public Frm_Agencia()
        {
            InitializeComponent();
            this.Text = "Cadastro de Agência";
            Tls_Principal.Items[0].ToolTipText = "Fechar a seleção";
        }

        private void ApagatoolStripButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tB_AgenciaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tB_AgenciaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.byteBankDataSet);

        }

        private void Frm_Agencia_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'byteBankDataSet.TB_Agencia'. Você pode movê-la ou removê-la conforme necessário.
            this.tB_AgenciaTableAdapter.Fill(this.byteBankDataSet.TB_Agencia);

        }
    }
}
