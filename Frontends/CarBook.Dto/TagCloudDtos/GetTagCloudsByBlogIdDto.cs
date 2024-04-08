using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TagCloudDtos
{
    public class GetTagCloudsByBlogIdDto
    {
        public int TagCloudId { get; set; }
        public string Name { get; set; }
        public int BlogId { get; set; }
    }
}
