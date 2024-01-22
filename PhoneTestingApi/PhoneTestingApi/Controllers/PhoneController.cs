using Microsoft.AspNetCore.Mvc;
using PhoneTestingApi.Data;
using PhoneTestingApi.Interface;
using PhoneTestingApi.Models;

namespace PhoneTestingApi.Controllers
{
    public class PhoneController : Controller
    {
        private readonly IphoneRepository _phoneRepository;

        public PhoneController(IphoneRepository PhoneRepository)
        {
          
                _phoneRepository = PhoneRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Phone>))]
        public IActionResult GetPhones()
        {
            var phone = _phoneRepository.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(phone);
        }


        [HttpGet("{phoneId}")]
        [ProducesResponseType(200, Type = typeof(Phone))]
        [ProducesResponseType(400)]
        public IActionResult GetPhone(int phoneId)
        {
            if (!_phoneRepository.DoesPhoneExists(phoneId))
            {
                return NotFound();
            }
            var phone = _phoneRepository.GetPhoneById(phoneId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(phone);

        }

        [HttpGet("/phonename")]
        [ProducesResponseType(200, Type = typeof(Phone))]
        [ProducesResponseType(400)]
        public IActionResult GetPhone(string name)
        {
            var phone = _phoneRepository.GetPhoneByName(name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(phone);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePhone([FromBody] Phone phonecreate ,[FromQuery] int categoryId)
        {
            if (phonecreate == null)
            {
                return BadRequest(ModelState);
            }
            var phone = _phoneRepository.GetAll()
                .Where(p => p.Name.Trim().ToUpper() == phonecreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (phone != null)
            {
                ModelState.AddModelError("", "phone already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var phoneMap = phonecreate;

            if (!_phoneRepository.CreatePhone(phoneMap, categoryId))
            {
                ModelState.AddModelError("", "something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("succesfully created");
        }
        [HttpPut("{phoneid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePhone(int phoneid, [FromBody] Phone UpdatedPhone)
        {
            if (UpdatePhone == null)
                return BadRequest(ModelState);

            if (phoneid != UpdatedPhone.Id)
            { return BadRequest(ModelState); }

            if (!_phoneRepository.DoesPhoneExists(phoneid))
            { return NotFound(); }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phoneMap = UpdatedPhone;
            if (!_phoneRepository.UpdatePhone(phoneMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpDelete("{phoneid}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePhone(int phoneid)
        {
            if (!_phoneRepository.DoesPhoneExists(phoneid))
            {
                return NotFound();
            }

            var DeleteToPhone = _phoneRepository.GetPhoneById(phoneid);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_phoneRepository.DeletePhone(DeleteToPhone))
            {
                ModelState.AddModelError("", "something went wrong while deleting");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}
