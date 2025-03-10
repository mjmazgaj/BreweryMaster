﻿using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.API.OrderModules.Models;

public interface IProspectOrderService
{
    Task<ProspectOrderDetails> GetProspectOrderDetails();
    Task<decimal> GetEstimatedPrice(ProspectPriceEstimationRequest request);
    Task<IEnumerable<ProspectOrderResponse>> GetProspectOrdersAsync(ProspectOrderFilterRequest? request);
    Task<ProspectOrderResponse?> GetProspectOrderByIdAsync(int id);
    Task<ProspectOrderResponse?> CreateProspectOrderAsync(ProspectOrderRequest rder);
    Task<bool> EditProspectOrderAsync(int id, ProspectOrderUpdateRequest order);
    Task<bool> DeleteProspectOrderByIdAsync(int id);
}