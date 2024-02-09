 public  Task<IEnumerable<Cart>> AddCart(int productId, int count);
  [HttpGet]
  [Route("cart")]
  public async Task<IActionResult> AddCart(int productId,int count)
  {
      try
      {
          var cloth = await _clothingRepository.AddCart(productId,count);
         
          return Ok(cloth);
      }
      catch (Exception ex)
      {
          return StatusCode(500, ex.Message);
      }
  }

   public async Task<IEnumerable<Cart>> AddCart([FromQuery] int productId,[FromQuery]int count)
   {
       var procedureName = "usp_insertcart";
       

       using (var connection = _dapperContext.CreateConnection())
       {
           var parameters = new DynamicParameters();
           parameters.Add("@productid", productId, DbType.Int32);
           parameters.Add("@count", count, DbType.Int32);
           var cart=await connection.QueryAsync<Cart>(procedureName, parameters, commandType: CommandType.StoredProcedure);
           //var updatedCart = await connection.QueryFirstOrDefaultAsync<Cart>("SELECT * FROM Cart WHERE ProductId = @ProductId", new { cart.productId });
           return cart.ToList();
       }
   }
