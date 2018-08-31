
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


        public Metadata GetMetadatabyId( int? metadaId)
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

        public void UpdateMetadata(Metadata metadata)
        {
            Metadata dataToupdate = db.Metadatas.Where(x => x.Metadata_Id == metadata.Metadata_Id).FirstOrDefault();
            try
            {
                dataToupdate.Metadata_Name = metadata.Metadata_Name;
                dataToupdate.IsActive = metadata.IsActive;


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