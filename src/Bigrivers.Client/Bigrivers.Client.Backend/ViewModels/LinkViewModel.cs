﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using Bigrivers.Server.Data;
using Bigrivers.Server.Model;

namespace Bigrivers.Client.Backend.Models
{
    public class LinkViewModel
    {
        private readonly BigriversDb _db = new BigriversDb();

        /// <summary>
        /// Variable to set either an internal, external or file link.
        /// </summary>
        [Display(Name = "Naar...")]
        public string LinkType { get; set; }

        /// <summary>
        /// ExternalURL is the field used when linking to a different website
        /// </summary>
        [Display(Name = "URL")]
        [DataType(DataType.Url)]
        public string ExternalUrl { get; set; }

        /// <summary>
        /// File is the field used when linking to a file in the Azurestorage
        /// </summary>
        [Display(Name = "Upload een bestand om naar te linken")]
        public File File { get; set; }

        /// <summary>
        ///  InternalType is the type of object that's being linked to when linking to an internal page
        /// </summary>
        [Display(Name = "Naar een...")]
        public string InternalType { get; set; }

        ///<summary>
        /// Internal*Id is the Id of the object being linked to when linking to an internal page 
        /// </summary>
        public string InternalEventId { get; set; }
        ///<summary>
        /// Internal*Id is the Id of the object being linked to when linking to an internal page 
        /// </summary>
        public string InternalArtistId { get; set; }
        ///<summary>
        /// Internal*Id is the Id of the object being linked to when linking to an internal page 
        /// </summary>
        public string InternalPerformanceId { get; set; }
        ///<summary>
        /// Internal*Id is the Id of the object being linked to when linking to an internal page 
        /// </summary>
        public string InternalNewsId { get; set; }
        ///<summary>
        /// Internal*Id is the Id of the object being linked to when linking to an internal page 
        /// </summary>
        public string InternalSponsorId { get; set; }

        public IEnumerable<SelectListItem> LinkTypes
        {
            get
            {
                return new[]
                {
                    new SelectListItem()
                    {
                        Text = "Sitepagina",
                        Value = "internal"
                    },
                    new SelectListItem()
                    {
                        Text = "Andere website",
                        Value = "external"
                    },
                    new SelectListItem()
                    {
                        Text = "Een bestand",
                        Value = "file"
                    }
                };
            }
        }

        public IEnumerable<SelectListItem> Types
        {
            get
            {
                return new[]
                {
                    new SelectListItem()
                    {
                        Text = "Evenementen",
                        Value = "Events"
                    },
                    new SelectListItem()
                    {
                        Text = "Artiesten",
                        Value = "Artists"

                    },
                    new SelectListItem()
                    {
                        Text = "Optredens",
                        Value = "Performances"
                    },
                    new SelectListItem()
                    {
                        Text = "Nieuwsberichten",
                        Value = "News"
                    },
                    new SelectListItem()
                    {
                        Text = "Sponsoren",
                        Value = "Sponsors"

                    },
                    new SelectListItem()
                    {
                        Text = "Contact",
                        Value = "Contact"

                    }
                };
            }
        }

        public List<SelectListItem> Events
        {
            get
            {
                var l = _db.Events
                .Where(m => !m.Deleted)
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Title
                }).ToList();
                l.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = ""
                });
                return l;
            }
        }

        public List<SelectListItem> Artists
        {
            get
            {
                var l = _db.Artists
                    .Where(m => !m.Deleted)
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.Name
                    }).ToList();
                l.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = ""
                });
                return l;
            }
        }

        public List<SelectListItem> Performances
        {
            get
            {
                var l = _db.Performances
                .Where(m => !m.Deleted)
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Artist.Name
                }).ToList();
                l.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = ""
                });
                return l;
            }
        }

        public List<SelectListItem> NewsItems
        {
            get
            {
                var l = _db.NewsItems
                .Where(m => !m.Deleted)
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Title
                }).ToList();
                l.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = ""
                });
                return l;
            }
        }

        public List<SelectListItem> Sponsors
        {
            get
            {
                var l = _db.Sponsors
                .Where(m => !m.Deleted)
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }).ToList();
                l.Insert(0, new SelectListItem
                {
                    Value = "",
                    Text = ""
                });
                return l;
            }
        }
    }
}