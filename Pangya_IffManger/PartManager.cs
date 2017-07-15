using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/// <summary>
/// Manager criado por ericv2_a@hotmail.com -> cavaleirodovent (ragezone)
/// </summary>

namespace Pangya_IffManger
{
    public class PartManager
    {
        public List<Part> Load(string filePatch)
        {
            //Lê todos os bytes do arquivo
            var data = File.ReadAllBytes(filePatch);

            //var totalParts = ((Data.Length - 8) / PartData);

            //Lê quantidade de Roupas disponíveis. Posição inicial: 0 do arquivo .iff
            var totalParts = BitConverter.ToUInt32(data, 0);

            //Para armazenar as roupas
            List<Part> partList = new List<Part>();

            //Loop para ler todas as roupas
            for (int i = 0; i < totalParts; i++)
            {
                //Cada roupa tem um total exato de 544 bytes
                var partData = new byte[544];

                //Lê a primeira roupa, cada roupa começa com o byte 01 (exemplo, posição 8 do arquivo)
                Buffer.BlockCopy(data, 544 * i + 8, partData, 0, 544);

                //Lê informações da roupa
                partList.Add(GetPart(partData));
            }

            return partList;

        }

        private Part GetPart(byte[] data)
        {
            return new Part()
            {
                Enabled = Convert.ToBoolean(data[0]), //Posição 0
                Id = data.ToIntenger(startIndex: 4, count: 4), //Posição 4
                Name = Encoding.ASCII.GetString(data.Skip(8).TakeWhile(x => x != 0x00).ToArray()), //Posição 8, lê o nome enquanto o byte for diferente de 0x00
                level = Convert.ToByte(data[48]),
                icon = Encoding.ASCII.GetString(data.Skip(49).TakeWhile(x => x != 0x00).ToArray()), //Posição 8, lê o nome enquanto o byte for diferente de 0x00

                falg = Convert.ToInt32(data[89]), //Posição 104
                Price = data.ToIntenger(startIndex: 92, count: 2), //Posição 92
                desconto = data.ToIntenger(startIndex: 96, count: 2), //Posição 96
                unknown = Convert.ToInt32(data[100]), //Posição 100
                PriceType = Convert.ToInt32(data[104]), //Posição 104
                qnt_per_tiki_pts = Convert.ToInt32(data[108]), //Posição 108
                tiki_points = Convert.ToInt32(data[112]), //Posição 104
                milage_pts = Convert.ToInt16(data[116]), //Posição 104
                bonus_prob = Convert.ToInt16(data[118]), //Posição 104
                milage_pts2 = Convert.ToInt16(data[120]), //Posição 104
                milage_pts3 = Convert.ToInt16(data[122]), //Posição 104
                tipo_tiki_shop = Convert.ToInt32(data[124]), //Posição 104
                tiki_pang = Convert.ToInt32(data[128]), //Posição 104
                active_date = Convert.ToInt32(data[132]), //Posição 104
                date_inicio = Encoding.ASCII.GetString(data.Skip(136).TakeWhile(x => x != 0x00).ToArray()), //<--- how to change value to DateTime?
                date_fim = Encoding.ASCII.GetString(data.Skip(152).TakeWhile(x => x != 0x00).ToArray()), //
                mpet = Encoding.ASCII.GetString(data.Skip(168).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                ucc_type = Convert.ToInt32(data[208]), //Posição 104
                part_type = Convert.ToInt32(data[212]), //Posição 104
                unknown2 = Convert.ToInt32(data[216]), //Posição 104
                textura_1 = Encoding.ASCII.GetString(data.Skip(220).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                textura_2 = Encoding.ASCII.GetString(data.Skip(260).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                textura_3 = Encoding.ASCII.GetString(data.Skip(300).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                textura_4 = Encoding.ASCII.GetString(data.Skip(340).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                textura_5 = Encoding.ASCII.GetString(data.Skip(380).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                textura_6 = Encoding.ASCII.GetString(data.Skip(420).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                //Attributes
                Power = Convert.ToInt32(data[460]), //Posição 460
                Control = Convert.ToInt32(data[462]),
                Accuracy = Convert.ToInt32(data[464]),
                Spin = Convert.ToInt32(data[466]),
                Curve = Convert.ToInt32(data[468]),

                //Slots
                PowerSlot = Convert.ToInt32(data[470]),
                ControlSlot = Convert.ToInt32(data[472]),
                AccuracySlot = Convert.ToInt32(data[474]),
                SpinSlot = Convert.ToInt32(data[476]),
                CurveSlot = Convert.ToInt32(data[478]),
                blank = Encoding.ASCII.GetString(data.Skip(480).TakeWhile(x => x != 0x00).ToArray()), //Posição 104
                unknown3 = Convert.ToInt32(data[528]), //Posição 104
                unknown4 = Convert.ToInt32(data[532]), //Posição 104
                valor_rental = Convert.ToInt32(data[536]), //Posição 104
                unknown5 = Convert.ToInt32(data[540])
            };
        }
    }
}
