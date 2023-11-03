using AAS2237A2.Data;
using AAS2237A2.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-b61a2cbe-93eb-49ea-bbe1-a509ad734246
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace AAS2237A2.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();

                // Invoice
                cfg.CreateMap<Invoice, InvoiceBaseViewModel>();
                cfg.CreateMap<Invoice, InvoiceWithDetailViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineBaseViewModel>();
                cfg.CreateMap<InvoiceLine, InvoiceLineWithDetailViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        public IEnumerable<TrackWithDetailViewModel> TrackGetAll()
        {
            var allTracks = ds.Tracks
                              .Include("Genre")
                              .Include("Album")
                              .Include("MediaType")
                              .OrderBy(t => t.Name);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(allTracks);
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetBluesJazz()
        {

            // TODO: 01 - confirm with prof if the query is correct or not.
            var blueJazzTracks = ds.Tracks
                                   .Include("Genre")
                                   .Include("Album")
                                   .Include("MediaType")
                                   .Where(t => t.GenreId == 2 || t.GenreId == 6)
                                   .OrderBy(t => t.Genre.Name)
                                   .ThenBy(t => t.Name);
                                   

            // Return the result
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(blueJazzTracks);
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetCantrellStaley() 
        {
            var allCantrellStaley = ds.Tracks
                                      .Include("Genre")
                                      .Include("Album")
                                      .Include("MediaType")
                                      .Where(t => t.Composer.Contains("Jerry Cantrell") && t.Composer.Contains("Layne Staley"))
                                      .OrderBy(t => t.Composer)
                                      .ThenBy(t => t.Name);

            // Return the result
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(allCantrellStaley);
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Longest()
        {
            var top50LongestTracks = ds.Tracks
                                       .Include("Genre")
                                       .Include("Album")
                                       .Include("MediaType")
                                       .OrderByDescending(t => t.Milliseconds)
                                       .ThenBy(t => t.Name)
                                       .Take(50);

            // Return the result
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(top50LongestTracks);
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetTop50Smallest()
        {
            var top50SmallestTracks = ds.Tracks
                                        .Include("Genre")
                                        .Include("Album")
                                        .Include("MediaType")
                                        .OrderBy(t => t.Bytes)
                                        .ThenBy(t => t.Name)
                                        .Take(50);

            // Return the result
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(top50SmallestTracks);
        }


        // Invoice
        public IEnumerable<InvoiceBaseViewModel> InvoiceGetAll() 
        {
            var allInvoices = ds.Invoices.OrderByDescending(i => i.InvoiceDate);
            return mapper.Map<IEnumerable<Invoice>, IEnumerable<InvoiceBaseViewModel>>(allInvoices);
        }

        public InvoiceWithDetailViewModel InvoiceGetByIdWithDetail(int theId)
        {
            var invoice = ds.Invoices
                //.Include("Customer")
                .Include("Customer.Employee")
                //.Include("InvoiceLines")
                //.Include("InvoiceLines.Track")
                .Include("InvoiceLines.Track.Genre")
                //.Include("InvoiceLines.Track.Album")
                .Include("InvoiceLines.Track.MediaType")
                .Include("InvoiceLines.Track.Album.Artist")
                .SingleOrDefault(i => i.InvoiceId == theId);

            // Check if invoice is null
            if (invoice == null)
            {
                return null; // Return null if no invoice is found
            }

            // Map the Invoice properties
            var invoiceWithDetailViewModel = mapper.Map<Invoice, InvoiceWithDetailViewModel>(invoice);

            // Map the InvoiceLines and assign them to the InvoiceWithDetailViewModel
            var invoiceLineViewModels = mapper.Map<IEnumerable<InvoiceLine>, IEnumerable<InvoiceLineWithDetailViewModel>>(invoice.InvoiceLines);
            invoiceWithDetailViewModel.InvoiceLines = invoiceLineViewModels;

            return invoiceWithDetailViewModel;
        }


    }
}