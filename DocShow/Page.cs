using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocShow
{
    [SugarTable("Page", IsDisabledUpdateAll = true)]
    public class Page
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Id { get; set; }

        [SugarColumn(ColumnName = "Title")]
        public string Title { get; set; }

        [SugarColumn(ColumnName = "Content")]
        public string Content { get; set; }

        [SugarColumn(ColumnName = "SendTime")]
        public DateTime SendTime { get; set; }
    }
}
