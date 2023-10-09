using AutoCore.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AutoCore.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : Controller
{
    private readonly IMapper _mapper;

    public ExampleController(IMapper mapper)
    {
        _mapper = mapper;
    }

    // [HttpGet("test")]
    // public ActionResult<DestinationClass> TestAction(SourceClass source)
    // {
    //     var destination = _mapper.Map<DestinationClass>(source);
    //     return Ok(destination);
    // }
    
    // 使用硬编码添加测试数据
    [HttpGet("test")]
    public ActionResult<DestinationClass> TestAction()
    {
        // Test Data
        var source = new SourceClass
        {
            FirstName = "Test Source First",
            LastName = "Test Source Last"
        };

        var destination = _mapper.Map<DestinationClass>(source);
        return Ok(destination);
    }
}