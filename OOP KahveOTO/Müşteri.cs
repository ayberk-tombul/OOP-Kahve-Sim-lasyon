using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KahveOTO
{

    public enum ÖdemeCinsi { nakit, kredikartı}

    public class Müşteri
    {

        private int BeklemeSüresi;

        public Sipariş SiparişVer()
        {
            KasalarıDinleme();
            return new Sipariş();
        }

        public Ödeme ÖdemeYap(decimal Tutar,ÖdemeCinsi cins)
        {
            switch (cins)
            {
                case ÖdemeCinsi.nakit:
                    return new NakitÖdeme();
                case ÖdemeCinsi.kredikartı:
                    return new KrediKartıÖdeme();
                default:
                    break;
            }
        }

        public Müşteri(int BeklemeSüresi)
        {
            this.BeklemeSüresi = BeklemeSüresi = 100;
            foreach (KasaElemanı item in AktifÇalışanlar.Instance.Kasalar())
            {
                item.Kasaboş += K_Kasaboş;
            }
            KasaElemanı k = new KasaElemanı();
            k.Kasaboş += K_Kasaboş;

        }

        private void KasalarıDinleme()
        {
            foreach (KasaElemanı item in AktifÇalışanlar.Instance.Kasalar())
            {
                item.Kasaboş -= K_Kasaboş;
            }
        }

        private void K_Kasaboş(object sender, EventArgs args)
        {
            ((KasaElemanı) sender).SiparişAl(this);
            KasalarıDinleme();
        }
    }
}
