using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("contacts")]
public class ContactsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContactsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        var contacts = await _context.Contacts.ToListAsync();
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContact(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        if (contact == null) return NotFound();
        return Ok(contact);
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] Contact contact)
    {
         if (!ModelState.IsValid)
        return BadRequest(ModelState);

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, [FromBody] Contact updatedContact)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null) return NotFound();

        contact.FirstName = updatedContact.FirstName;
        contact.LastName = updatedContact.LastName;
        contact.Email = updatedContact.Email;
        contact.PhoneNumber = updatedContact.PhoneNumber;
        contact.Address = updatedContact.Address;
        contact.DateOfBirth = updatedContact.DateOfBirth;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact == null) return NotFound();

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
