using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20241104_AgendaTelefonicaV3
{
    internal class Contato
    {
        
        public string nome { get; set; }
        public string telefone { get; set; }
        public int idTipo { get; set; }

        public Contato(string nome, string telefone, int idTipo)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.idTipo = idTipo;
        }

        public override string ToString()
        {
            return this.nome;
        }

        
    }
}
