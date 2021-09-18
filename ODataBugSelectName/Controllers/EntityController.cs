using System;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ODataBugSelectName.Controllers
{
    [ApiController]
    [Route("/[controller]/[action]")]
    public class EntityController : ControllerBase
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public EntityController(MyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

            _db.Database.EnsureCreated();
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(ODataQueryOptions<MyResponse> options)
        {
            return Ok(await _db.Entities.GetQueryAsync(_mapper, options, null));
        }
    }

    public class MyResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<MyEntity, MyResponse>()
                .ForAllMembers(x => x.ExplicitExpansion());
        }
    }
}