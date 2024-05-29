using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json_process_from_jsonfile
{
    internal class Megrendeles
    {
        private int id_;
        private Dolgozo dolgozo_;
        private string munkalapSzama_;
        private Alapanyag alapanyag_;
        private DateTime datumKezdes_;
        private DateTime datumBefejezes_;
        private int felhasznaltMennyiseg_;

        public Megrendeles(int id_, Dolgozo dolgozo_, string munkalapSzama_, Alapanyag alapanyag_, DateTime datumKezdes_, DateTime datumBefejezes_, int felhasznaltMennyiseg_)
        {
            this.Id_ = id_;
            this.Dolgozo_ = dolgozo_;
            this.MunkalapSzama_ = munkalapSzama_;
            this.Alapanyag_ = alapanyag_;
            this.DatumKezdes_ = datumKezdes_;
            this.DatumBefejezes_ = datumBefejezes_;
            this.FelhasznaltMennyiseg_ = felhasznaltMennyiseg_;
        }

        public int Id_ { get => id_; set => id_ = value; }
        public string MunkalapSzama_ { get => munkalapSzama_; set => munkalapSzama_ = value; }
        public DateTime DatumKezdes_ { get => datumKezdes_; set => datumKezdes_ = value; }
        public DateTime DatumBefejezes_ { get => datumBefejezes_; set => datumBefejezes_ = value; }
        public int FelhasznaltMennyiseg_ { get => felhasznaltMennyiseg_; set => felhasznaltMennyiseg_ = value; }
        internal Dolgozo Dolgozo_ { get => dolgozo_; set => dolgozo_ = value; }
        internal Alapanyag Alapanyag_ { get => alapanyag_; set => alapanyag_ = value; }

        public override string ToString()
        {
            
            return $"megrendelés id: {Id_}\nmunkalap száma: {MunkalapSzama_}\nkezdés: " +
                $"{DatumKezdes_}\nbefejezes: {DatumBefejezes_}\nmennyiség: {FelhasznaltMennyiseg_}\n" +
                $"dolgozó:\n{Dolgozo_}\nalapanyag:\n{Alapanyag_}\n\n";
        }
    }
}
