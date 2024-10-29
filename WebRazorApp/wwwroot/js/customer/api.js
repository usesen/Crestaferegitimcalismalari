// API çağrıları
const CustomerAPI = {
    getList: async (params) => {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/getpaged?${params}`);
        if (!response.ok) throw new Error('API error');
        return response.json();
    },
    // ... diğer API çağrıları
};