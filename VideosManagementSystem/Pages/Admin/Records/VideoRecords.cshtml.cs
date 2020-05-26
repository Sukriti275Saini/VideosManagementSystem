using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideosManagementSystem.Core;
using VideosManagementSystem.Data;

namespace VideosManagementSystem.Pages.Admin.Records
{
    public class VideoRecordsModel : PageModel
    {
        private readonly IUVRecordData db;

        public VideoRecordsModel(IUVRecordData db)
        {
            this.db = db;
        }

        public IEnumerable<UsersVideoRecord> allrecords { get; set; }

        public void OnGet()
        {
            allrecords = db.GetAllRecords();
        }
    }
}