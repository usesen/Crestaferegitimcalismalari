// UI işlemleri
const CustomerUI = {
    displayList: (data) => {
        const tableBody = document.getElementById('customerTableBody');
        tableBody.innerHTML = '';

        data.items.forEach(customer => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${customer.id}</td>
                <td>${customer.firstName} ${customer.lastName}</td>
                <td>${customer.email}</td>
                <td>${customer.company}</td>
                <td>${customer.city}</td>
                <td>${customer.country}</td>
                <td class="text-center">
                    <button class="btn btn-info btn-sm" onclick="showCustomer(${customer.id})">
                        <i class="fas fa-eye"></i>
                    </button>
                    <button class="btn btn-warning btn-sm" onclick="editCustomer(${customer.id})">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button class="btn btn-danger btn-sm" onclick="deleteCustomer(${customer.id})">
                        <i class="fas fa-times"></i>
                    </button>
                </td>
            `;
            tableBody.appendChild(row);
        });
    },

    updatePagination: (data) => {
        const pagination = document.querySelector('.pagination');
        if (!pagination) return;

        pagination.innerHTML = '';

        // Önceki sayfa
        pagination.appendChild(CustomerUI.createPageItem(
            data.currentPage === 1,
            data.currentPage - 1,
            'Önceki'
        ));

        // Sayfa numaraları
        for (let i = 1; i <= data.totalPages; i++) {
            pagination.appendChild(CustomerUI.createPageItem(
                false,
                i,
                i.toString(),
                data.currentPage === i
            ));
        }

        // Sonraki sayfa
        pagination.appendChild(CustomerUI.createPageItem(
            data.currentPage === data.totalPages,
            data.currentPage + 1,
            'Sonraki'
        ));
    },

    createPageItem: (isDisabled, pageNumber, text, isActive = false) => {
        const li = document.createElement('li');
        li.className = `page-item ${isDisabled ? 'disabled' : ''} ${isActive ? 'active' : ''}`;
        li.innerHTML = `
            <a class="page-link" href="#" onclick="changePage(${pageNumber}); return false;">
                ${text}
            </a>
        `;
        return li;
    }
};