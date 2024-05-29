using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json_process_from_jsonfile
{
    internal class Alapanyag
    {
        private int id_;
        private string anyagtipusa_;
        private double vastagsag_;
        private string meret_;
        private int darabszam_;
        private int polc_szama_;
        private DateTime rogzit_datum;

        public Alapanyag(int id_, string anyagtipusa_, double vastagsag_, string meret_, int darabszam_, int polc_szama_, DateTime rogzit_datum)
        {
            this.Id_ = id_;
            this.Anyagtipusa_ = anyagtipusa_;
            this.Vastagsag_ = vastagsag_;
            this.Meret_ = meret_;
            this.Darabszam_ = darabszam_;
            this.Polc_szama_ = polc_szama_;
            this.Rogzit_datum = rogzit_datum;
        }

        public int Id_ { get => id_; set => id_ = value; }
        public string Anyagtipusa_ { get => anyagtipusa_; set => anyagtipusa_ = value; }
        public double Vastagsag_ { get => vastagsag_; set => vastagsag_ = value; }
        public string Meret_ { get => meret_; set => meret_ = value; }
        public int Darabszam_ { get => darabszam_; set => darabszam_ = value; }
        public int Polc_szama_ { get => polc_szama_; set => polc_szama_ = value; }
        public DateTime Rogzit_datum { get => rogzit_datum; set => rogzit_datum = value; }

        public override string ToString()
        {
            return $"\tanyagtípus: {Anyagtipusa_}\n\tvastagsag: {Vastagsag_}\n\tméret: {Meret_}";
        }
    }
}
