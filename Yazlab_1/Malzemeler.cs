﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Yazlab_1
{
    public class Malzemeler
    {
       
        public int MalzemeID { get; set; }
        public string MalzemeAdi { get; set; }
        public string ToplamMiktar { get; set; }
        public string MalzemeBirim { get; set; }
        public decimal BirimFiyat { get; set; }

    }
}
