using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Collections.Generic;
using System.Linq;
namespace TravelUpApp_AI_ML.Controllers
{
    [Route("api/predict")]
    [ApiController]
    public class PredictController : ControllerBase
    {
        [HttpPost]
        public IActionResult Predict([FromBody] float[] input)
        {
            using var session = new InferenceSession("booking_model.onnx");
            var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input", new DenseTensor<float>(input, new[] { 1, input.Length }))
        };
            using var results = session.Run(inputs);
            float prediction = results.First().AsEnumerable<float>().First();
            return Ok(new { prediction });
        }
    }
}
