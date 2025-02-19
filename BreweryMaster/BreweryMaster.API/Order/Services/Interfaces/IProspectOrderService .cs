﻿using BreweryMaster.API.OrderModule.Models;

public interface IProspectOrderService
{
    Task<ProspectOrderDetails> GetProspectOrderDetails();
    Task<decimal> GetEstimatedPrice(ProspectPriceEstimationRequest request);
    Task<IEnumerable<ProspectOrderResponse>> GetProspectOrdersAsync();
    Task<ProspectOrder?> GetProspectOrderByIdAsync(int id);
    Task<ProspectOrder?> CreateProspectOrderAsync(ProspectOrderRequest rder);
    Task<bool> EditProspectOrderAsync(int id, ProspectOrder order);
    Task<bool> DeleteProspectOrderByIdAsync(int id);
}