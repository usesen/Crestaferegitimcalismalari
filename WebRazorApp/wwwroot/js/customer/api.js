class CustomerAPI {
    static async getCustomers(params) {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/getpaged?${params.toString()}`);
        if (!response.ok) {
            throw new Error('Veriler yüklenirken bir hata oluştu');
        }
        return response.json();
    }

    static async getCustomer(id) {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/${id}`);
        if (!response.ok) {
            throw new Error('Müşteri bilgileri alınamadı!');
        }
        return response.json();
    }

    static async createCustomer(customerData) {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(customerData)
        });
        if (!response.ok) {
            throw new Error('Müşteri eklenirken bir hata oluştu!');
        }
        return response.json();
    }

    static async updateCustomer(id, customerData) {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(customerData)
        });
        if (!response.ok) {
            throw new Error('Müşteri güncellenirken bir hata oluştu!');
        }
        return response.json();
    }

    static async deleteCustomer(id) {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/${id}`, {
            method: 'DELETE'
        });
        if (!response.ok) {
            throw new Error('Müşteri silinirken bir hata oluştu!');
        }
        return response.json();
    }

    static async exportCustomers(params) {
        const response = await fetch(`${API_CONFIG.baseUrl}${API_CONFIG.endpoints.customer}/getpaged?${params.toString()}`);
        if (!response.ok) {
            throw new Error('Veriler alınamadı!');
        }
        return response.json();
    }
}

// Dışa aktar
window.CustomerAPI = CustomerAPI;