using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Medicamento
{
    class Lote
    {
        #region atributos

        int id;
        int qtde;
        DateTime venc;

        #endregion

        #region propriedades

        public int Id { get { return this.id; } set { id = value; } }
        public int Qtde { get { return this.qtde; }set { qtde = value; } }
        public DateTime Venc { get { return this.venc; } set { venc = value; } }

        #endregion

        #region construtores

        public Lote() {

        }

        public Lote(int id, int qtde, DateTime venc) {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }

        #endregion

        #region Métodos

        public string toString() {
            // retornar id + “-“ + qtde + “-“ + venc
            string str = " - Lote Id: " + Id + " - Quantidade: " + Qtde + " - Vencimento em: " + Venc;
            return str;
        }
        public override bool Equals(object obj)
        {
            Lote l = ((Lote)obj);
            return this.id.Equals(l.Id);
        }
        #endregion
    }
}
