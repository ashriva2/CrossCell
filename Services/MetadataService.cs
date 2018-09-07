
using CrossSell_App.Repository;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Services
{
    public class MetadataService
    {

        private MetadataRepository repo = new MetadataRepository();
        public List<Metadata> GetAllMetadata()
        {
            return repo.GetAllMetadata();



            //var dataToReturn = data.Select(p => new MetadataTO()
            //{
            //     Metadata_Name=p.Metadata_Name,
            //     Metadata_Id=p.Metadata_Id,
            //     IsActive=p.IsActive
               
            //}).ToList();

            //return dataToReturn;
        }


        public Metadata GetMetadatabyId( int? metadaId)
        {
            return repo.GetMetadatabyId(metadaId);
            //return db.Metadatas.Where(x=>x.Metadata_Id==metadaId).Select(p=> new MetadataTO {
            //     Metadata_Name=p.Metadata_Name,
            //     Metadata_Id=p.Metadata_Id,
            //     IsActive=p.IsActive
            //}).FirstOrDefault();
        }


        public void SaveMetadata(Metadata data)
        {
            repo.SaveMetadata(data);

            //Metadata datatoSave = new Metadata()
            //{
            //    Metadata_Id = data.Metadata_Id,
            //    Metadata_Name = data.Metadata_Name,
            //    IsActive = true
            //};
            

            //try
            //{
            //    db.Metadatas.Add(datatoSave);
            //    db.SaveChanges();
            //}
            //catch(Exception ex)
            //{

            //}
        }

        public void UpdateMetadata(Metadata metadata)
        {
            //Metadata dataToupdate = db.Metadatas.Where(x => x.Metadata_Id == metadata.Metadata_Id).FirstOrDefault();
            repo.UpdateMetadata(metadata);
            //try
            //{
            //    dataToupdate.Metadata_Name = metadata.Metadata_Name;
            //    dataToupdate.IsActive = metadata.IsActive;


            //    db.SaveChanges();
            //}
            //catch(Exception ex)
            //{

            //}
        }

        public void DeleteMetadata(int id)
        {
            repo.DeleteMetadata(id);
            //Metadata metadata = db.Metadatas.Find(id);
            //metadata.IsActive = false;
            //try
            //{
             
            //  //  db.Metadatas.Remove(metadata);
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //}
        }

        //private bool disposed = false;
        //public void Dispose(bool disposing)
        //{
        //    if (!this.disposed)

        //    {

        //        if (disposing)

        //        {

        //            db.Dispose();

        //        }

        //    }

        //    this.disposed = true;
        //}
        //public void Dispose()

        //{

        //    Dispose(true);

        //    GC.SuppressFinalize(this);

        //}
    }
}