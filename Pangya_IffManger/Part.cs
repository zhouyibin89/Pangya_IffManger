using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pangya_IffManger.PartManager;

namespace Pangya_IffManger
{
    public enum PriceTypeEnum
    {
        Pang = 0x22,
        Pang_Purchase_Only_PINTINHO = 0x60,
        Cookie = 0x21,
    }

    /// <summary>
    /// Cada part.iff tem exatos 544 bytes
    /// </summary>
    public class Part
    {
        public bool Enabled { get; set; }//4
        public int Id { get; set; } //public int Id2 { get; set; }  4
        public string Name { get; set; }//8
        public byte level { get; set; }//48
        public string icon { get; set; }//49
        public int falg { get; set; }//89
        public int Price { get; set; }//92
        public int desconto { get; set; }//96
        public int unknown { get; set; }//
        public int PriceType { get; set; }//104
        public int qnt_per_tiki_pts { get; set; }//
        public int tiki_points { get; set; }//
        public int milage_pts { get; set; }//
        public int bonus_prob { get; set; }//
        public int milage_pts2 { get; set; }//
        public int milage_pts3 { get; set; }//
        public int tipo_tiki_shop { get; set; }//
        public int tiki_pang { get; set; }//
        public int active_date { get; set; }//
        public string date_inicio { get; set; }// <--- how to change value to DateTime?
        public string date_fim { get; set; }//<--- how to change value to DateTime?
        public string mpet { get; set; }//
        public int ucc_type { get; set; }//
        public int part_type { get; set; }//
        public int unknown2 { get; set; }//
        public string textura_1 { get; set; }//
        public string textura_2 { get; set; }//
        public string textura_3 { get; set; }//
        public string textura_4 { get; set; }//
        public string textura_5 { get; set; }//
        public string textura_6 { get; set; }//
        public int Power { get; set; } //Index 460
        public int Control { get; set; } //Index 462
        public int Accuracy { get; set; } //Index 464
        public int Spin { get; set; } //Index 466
        public int Curve { get; set; } //Index 468
        public int PowerSlot { get; set; } //Index 470
        public int ControlSlot { get; set; } //Index 472
        public int AccuracySlot { get; set; } //Index 474
        public int SpinSlot { get; set; } //Index 476
        public int CurveSlot { get; set; } //Index 47
        public string blank { get; set; }
        public int unknown3 { get; set; }
        public int unknown4 { get; set; }
        public int valor_rental { get; set; }
        public int unknown5 { get; set; }
    }
}
