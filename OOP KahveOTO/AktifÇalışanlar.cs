using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KahveOTO
{
    public class AktifÇalışanlar : ICollection<AktifÇalışan>
    {
        private static AktifÇalışanlar _singleton;

        public static AktifÇalışanlar GetInstance()
        {
            if (_singleton == null)
                _singleton = new AktifÇalışanlar();
            return _singleton;
        }

        public static AktifÇalışanlar Instance 
        { get 
            { if (_singleton == null)
                    _singleton = new AktifÇalışanlar();
                return _singleton;
            } 
        } 


        private List<AktifÇalışan> aktifler;

        public int Count => ((ICollection<AktifÇalışan>)aktifler).Count;

        public bool IsReadOnly => ((ICollection<AktifÇalışan>)aktifler).IsReadOnly;

        public void Add(AktifÇalışan item)
        {
            ((ICollection<AktifÇalışan>)aktifler).Add(item);
        }

        public void Clear()
        {
            ((ICollection<AktifÇalışan>)aktifler).Clear();
        }

        public bool Contains(AktifÇalışan item)
        {
            return ((ICollection<AktifÇalışan>)aktifler).Contains(item);
        }

        public void CopyTo(AktifÇalışan[] array, int arrayIndex)
        {
            ((ICollection<AktifÇalışan>)aktifler).CopyTo(array, arrayIndex);
        }

        public IEnumerator<AktifÇalışan> GetEnumerator()
        {
            return ((IEnumerable<AktifÇalışan>)aktifler).GetEnumerator();
        }

        public bool Remove(AktifÇalışan item)
        {
            return ((ICollection<AktifÇalışan>)aktifler).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)aktifler).GetEnumerator();
        }

        public ICollection<KasaElemanı> Kasalar()
        {
            List<KasaElemanı> kasaElemanları = new List<KasaElemanı>();
            foreach (AktifÇalışan item in aktifler)
            {
                try
                {
                    kasaElemanları.Add((KasaElemanı)item);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return kasaElemanları;
        }

        public ICollection<Ödeme> GünlükÖdemeRaporu()
        {
            List<Ödeme> tümÖdemeler = new List<Ödeme>();
            
            foreach (KasaElemanı çalışan in this.Kasalar())
            {
                    tümÖdemeler.AddRange((çalışan).Ödemeler);
            }
            return tümÖdemeler;
        }

        public Barista BoştaolanBarista()
        {
            foreach (AktifÇalışan item in aktifler)
            {
                try
                {
                    Barista barista = (Barista)item;
                    if(barista.isBoşta)
                        return barista;
                }
                catch (Exception)
                {

                    //dinlemiyorum.
                }
            }
            throw new ExceptionBoştaOlanBaristaYok();
        }

        private AktifÇalışanlar()
        {
            aktifler = new List<AktifÇalışan>();
        }



    }
}


public class ExceptionBoştaOlanBaristaYok : Exception
{
    public ExceptionBoştaOlanBaristaYok() : base("Boşta Olan Barista Yok")
    {

    }
}