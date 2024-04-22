using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/v1/[controller]")]
public abstract class BaseControllerV1 : Controller {}