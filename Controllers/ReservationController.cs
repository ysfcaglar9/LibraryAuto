using LibraryAuto.EfCore;
using LibraryAuto.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAuto.Controllers
{

    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly DbHelper _db;


        public ReservationController(Ef_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        // GET: api/<ReservationController>
        [HttpGet]
        [Route("api/[controller]/GetBooks")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<BookModel> data = _db.GetBook();
                type = ResponseType.Success;
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }

                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        // GET api/<ReservationController>/
        [HttpGet]
        [Route("api/[controller]/GetBooksById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                BookModel data = _db.GetBookById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }

                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<ReservationController>
        [HttpPost]
        [Route("api/[controller]/saveBook")]
        public IActionResult Post([FromBody] BookModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpPost]
        [Route("api/[controller]/saveReservation")]
        public IActionResult PostReservation([FromBody] ReservedModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveReserved(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ReservationController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateBook")]
        public IActionResult Put(BookModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.UpdateBook(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteBook/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                ResponseType type = ResponseType.Success;
                _db.DeleteOrder(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {

                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

