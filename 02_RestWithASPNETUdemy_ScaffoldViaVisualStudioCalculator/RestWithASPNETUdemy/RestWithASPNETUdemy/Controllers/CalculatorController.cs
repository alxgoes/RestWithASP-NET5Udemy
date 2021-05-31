using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult Get(string firstnumber, string secondnumber)      
        {
            {
                if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
                {
                    var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber);
                    return Ok(sum.ToString());
                }
            }
            return BadRequest("Invalid Input");
        }
       private bool IsNumeric(string strnumber)
        {
            double number;
            bool isNumber = double.TryParse(strnumber,
                               System.Globalization.NumberStyles.Any,
                               System.Globalization.NumberFormatInfo.InvariantInfo,
                               out number);
            return isNumber;

        }
        private decimal ConvertToDecimal(string strnumber)
        {
            decimal decimalvalue;
            if (decimal.TryParse(strnumber, out decimalvalue))
            {
                return decimalvalue;
            }
            return 0;
        }

 
    }
}
