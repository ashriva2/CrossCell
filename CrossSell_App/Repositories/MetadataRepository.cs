using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrossSell_App.Repository
{
    public class MetadataRepository:IDisposable
    {

        private PAL_DigitalPicEntities db = new PAL_DigitalPicEntities();
        public List<Metadata> GetAllMetadata()
        {
            return db.Metadatas.ToList();
        }

        public Metadata GetAllMetadata( int? metadaId)
        {
            return db.Metadatas.Where(x=>x.Metadata_Id==metadaId).FirstOrDefault();
        }


        public void SaveMetadata(Metadata data)
        {
            try
            {
                db.Metadatas.Add(data);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public void UpdateMetadata(Metadata dataToUpdate)
        {
            try
            {
                db.Entry(dataToUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public void DeleteMetadata(int id)
        {
            Metadata metadata = db.Metadatas.Find(id);
            try
            {
             
                db.Metadatas.Remove(metadata);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)

            {

                if (disposing)

                {

                    db.Dispose();

                }

            }

            this.disposed = true;
        }
        public void Dispose()

        {

            Dispose(true);

            GC.SuppressFinalize(this);

        }
    }
}