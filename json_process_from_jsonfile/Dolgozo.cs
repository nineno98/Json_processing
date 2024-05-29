using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace json_process_from_jsonfile
{
    internal class Dolgozo
    {
        private string dolgozoUserName_;
        private string dolgozoFirstName_;
        private string dolgozoLastName_;

        public Dolgozo(string dolgozoUserName_, string dolgozoFirstName_, string dolgozoLastName_)
        {
            this.DolgozoUserName_ = dolgozoUserName_;
            this.DolgozoFirstName_ = dolgozoFirstName_;
            this.DolgozoLastName_ = dolgozoLastName_;
        }

        public string DolgozoUserName_ { get => dolgozoUserName_; set => dolgozoUserName_ = value; }
        public string DolgozoFirstName_ { get => dolgozoFirstName_; set => dolgozoFirstName_ = value; }
        public string DolgozoLastName_ { get => dolgozoLastName_; set => dolgozoLastName_ = value; }

        public override string ToString()
        {
            return $"\tfelhasználónév: {DolgozoUserName_}\n\tcsaládnév: {DolgozoFirstName_}" +
                $"\n\tkeresztnév: {DolgozoLastName_}";
        }
    }
}
