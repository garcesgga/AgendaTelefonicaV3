using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula20241104_AgendaTelefonicaV3
{
    public partial class Form1 : Form
    {
        private List<Contato> listaContatos;
        private List<String> listaTipos;

        public Form1()
        {
            InitializeComponent();
            btnAdicionar.Enabled = false;
            listaContatos = new List<Contato>();
            listaTipos = new List<String>();
            listaTipos.AddRange(new string[] { "", "Celular","Whatsapp", "Residencial"});
            cbxTipo.DataSource = listaTipos;
        }

        private void cbxAceito_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAceito.Checked)
            {
                btnAdicionar.Enabled = true;
            }
            else {
                btnAdicionar.Enabled = false;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (cbxAceito.Checked)
            {
                if (!string.IsNullOrEmpty(txbNome.Text) &&
                    !string.IsNullOrEmpty(txbTelefone.Text)&&
                    cbxTipo.SelectedIndex>0)
                {
                    Contato temp = new Contato(txbNome.Text, txbTelefone.Text,
                        cbxTipo.SelectedIndex);
                    listaContatos.Add(temp);

                    txbNome.Clear();
                    txbTelefone.Clear();
                    cbxTipo.SelectedIndex = -1;
                    cbxAceito.Checked = false;

                    AtualizaGrid();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos");
                }
            }
            else {
                MessageBox.Show("Aceite os termos.");
            }
        }

        private void AtualizaGrid() {
            dgvContatos.DataSource = null;
            dgvContatos.DataSource = listaContatos;

            dgvContatos.Columns["Nome"].DisplayIndex = 0;
            dgvContatos.Columns["Telefone"].DisplayIndex = 1;
            dgvContatos.Columns["Tipo"].DisplayIndex = 2;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(dgvContatos.SelectedRows.Count > 0)
            {
                int index = dgvContatos.SelectedRows[0].Index;
                if (index >= 0 && index<listaContatos.Count)
                {
                    listaContatos.RemoveAt(index);
                    AtualizaGrid();
                }

                //Testar DialogResult
                //DialogResult result = MessageBox.Show("Deseja excluir o contato selecionado?",
                //   "Excluir", MessageBoxButtons.YesNo);
                //testar também com o método RemoveAt
                //listaContatos.RemoveAt(dgvContatos.SelectedRows[0].Index);
                //AtualizaGrid();

            }
            else
            {
                MessageBox.Show("Selecione um contato para excluir.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dgvContatos.CurrentCell != null) 
            {
                int index = dgvContatos.CurrentCell.RowIndex;
                if (index >= 0 && index < listaContatos.Count)
                {
                    Contato contatoselecionado = listaContatos[index];
                    contatoselecionado.nome = dgvContatos.Rows[index].Cells["Nome"].Value?.ToString();
                    contatoselecionado.telefone = dgvContatos.Rows[index].Cells["Telefone"].Value?.ToString();
                    contatoselecionado.idTipo = Convert.ToInt32(dgvContatos.Rows[index].Cells["Tipo"].Value?.ToString());
                    AtualizaGrid();
                }
                else
                {
                    MessageBox.Show("Selecione um contato para Editar.");
                }
            }

            else
            {
                MessageBox.Show("Selecione um contato para Salvar.");
            }
        }
    }
}
