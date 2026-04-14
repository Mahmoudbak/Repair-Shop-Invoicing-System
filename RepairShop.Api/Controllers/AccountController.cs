using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repair_Shop_Invoicing_System.Dtos;
using Repair_Shop_Invoicing_System.Errors;
using Repair_Shop_Invoicing_System.Extensions;
using RepairShop.core;
using RepairShop.core.Customers;
using RepairShop.core.Entity.Identity;
using RepairShop.core.Identity;
using RepairShop.core.Service.Content;
using System.Security.Claims;

namespace Repair_Shop_Invoicing_System.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IAuthService _authService;
    private readonly IMapper _mapper;
    private readonly IcustomerService _customerservice;

    public AccountController(UserManager<ApplicationUser>userManager,
        SignInManager<ApplicationUser> signInManager,IAuthService authService,IMapper mapper,IcustomerService customerservice)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _authService = authService;
        _mapper = mapper;
        _customerservice = customerservice;
    }



    [HttpPost("Login")]
    public async Task<ActionResult<userDto>> Login(LoginDto model)
    {
        var user=await   _userManager.FindByEmailAsync(model.Email);
        if (user is null) return Unauthorized(new ApiResponse(401 ,"Invalid Login"));
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        
        if (!result.Succeeded) return Unauthorized(new ApiResponse(401 ,"Invalid Login"));
       

        return Ok(new userDto()
        {
            DisplayName = user.DisplayName,
            Email = user.Email ?? string.Empty,
            Token = await _authService.CreateTokenAsync(user,_userManager)
        });
    }

    
    
    [HttpPost("Register")]
    public async Task<ActionResult<userDto>> Register(RegisterDto model)
    {
        var user = new ApplicationUser()
        {
            DisplayName = model.DisplayName,
            Email = model.Email,
            UserName = model.Email.Split("@")[0],
            PhoneNumber = model.Phone
        };
        var result=await _userManager.CreateAsync(user, model.Password);


        if (!result.Succeeded)
            return BadRequest(new apiValidationErrorResponse() { Errors = result.Errors.Select(E => E.Description) });

        await _customerservice.CreateCustomerAsync(model.DisplayName, model.Email,model.Phone);

        return Ok(new userDto
        {
            DisplayName = user.DisplayName,
            Email = user.Email??string.Empty,
            Token = await _authService.CreateTokenAsync(user,_userManager)
            
        });
    }


    [Authorize]
    [HttpGet]
    public async Task<ActionResult<userDto>> GetCurrentUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email)??string.Empty;
        
        var user=await   _userManager.FindByEmailAsync(email);


        return Ok(new userDto
        {   
            DisplayName = user.DisplayName??string.Empty,
            Email = user.Email??string.Empty,
            Token = await _authService.CreateTokenAsync(user,_userManager)
        });
        
    }



    [Authorize]
    [HttpGet("address")]
    public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
    {
        var user=await _userManager.FindUserWithAddressAsync(User);
        return Ok(_mapper.Map<AddressDto>(user.Address));
        
    }


    [Authorize]
    [HttpPut("address")]
    public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
    {
        var UpdateAddress=_mapper.Map<Address>(address);
        var user=await _userManager.FindUserWithAddressAsync(User);

       // UpdateAddress.Id = user.Address.Id;

        user.Address=UpdateAddress;
        
        
        var result= await _userManager.UpdateAsync(user);
        
        if (!result.Succeeded) return BadRequest(new apiValidationErrorResponse(){Errors = result.Errors.Select(E => E.Description)});

        return Ok(address);
    }
    
    
    
    
    
}