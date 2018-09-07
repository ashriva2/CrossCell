
using DataAccessLayer;
using DTO;
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
        public List<MetadataTO> GetAllMetadata()
        {
            var data = db.Metadatas.ToList().Where(x => x.Metadata_Id != 7 && x.IsActive==true).OrderBy(x => x.Metadata_Id).ToList();



            var dataToReturn = data.Select(p => new MetadataTO()
            {
                 Metadata_Name=p.Metadata_Name,
                 Metadata_Id=p.Metadata_Id,
                 IsActive=p.IsActive
               
            }).ToList();

            return dataToReturn;
        }


        public MetadataTO GetMetadatabyId( int? metadaId)
        {
            return db.Metadatas.Where(x=>x.Metadata_Id==metadaId).Select(p=> new MetadataTO {
                 Metadata_Name=p.Metadata_Name,
                 Metadata_Id=p.Metadata_Id,
                 IsActive=p.IsActive
            }).FirstOrDefault();
        }


        public void SaveMetadata(MetadataTO data)
        {
            Metadata datatoSave = new Metadata()
            {
                Metadata_Id = data.Metadata_Id,
                Metadata_Name = data.Metadata_Name,
                IsActive = true
            };
            

            try
            {
                db.Metadatas.Add(datatoSave);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public void UpdateMetadata(MetadataTO metadata)
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
            metadata.IsActive = false;
            try
            {
             
              //  db.Metadatas.Remove(metadata);
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