// UI yapılandırması
const UI_CONFIG = {
    pageSize: 10,
    toastr: {
        closeButton: true,
        debug: false,
        newestOnTop: true,
        progressBar: true,
        positionClass: "toast-top-right",
        preventDuplicates: false,
        onclick: null,
        showDuration: "300",
        hideDuration: "1000",
        timeOut: "5000",
        extendedTimeOut: "1000",
        showEasing: "swing",
        hideEasing: "linear",
        showMethod: "fadeIn",
        hideMethod: "fadeOut"
    }
};

// UI işlemleri için sınıf
class CustomerUI {
    static showLoading() {
        const loadingHtml = `
            <div class="loading-spinner">
                <div class="spinner-border text-primary" role="status">
                    <span class="visually-hidden">Yükleniyor...</span>
                </div>
            </div>`;
        document.body.insertAdjacentHTML('beforeend', loadingHtml);
    }

    static hideLoading() {
        const spinner = document.querySelector('.loading-spinner');
        if (spinner) spinner.remove();
    }

    static showAlert(type, message) {
        toastr[type](message);
    }

    static updatePagination(data) {
        const pagination = document.querySelector('.pagination');
        if (!pagination) return;

        pagination.innerHTML = '';

        // Önceki sayfa
        const prevLi = document.createElement('li');
        prevLi.className = `page-item ${data.currentPage === 1 ? 'disabled' : ''}`;
        prevLi.innerHTML = `
            <a class="page-link" href="#" onclick="changePage(${data.currentPage - 1}); return false;">
                Önceki
            </a>
        `;
        pagination.appendChild(prevLi);

        // Sayfa numaraları
        for (let i = 1; i <= data.totalPages; i++) {
            const li = document.createElement('li');
            li.className = `page-item ${data.currentPage === i ? 'active' : ''}`;
            li.innerHTML = `
                <a class="page-link" href="#" onclick="changePage(${i}); return false;">
                    ${i}
                </a>
            `;
            pagination.appendChild(li);
        }

        // Sonraki sayfa
        const nextLi = document.createElement('li');
        nextLi.className = `page-item ${data.currentPage === data.totalPages ? 'disabled' : ''}`;
        nextLi.innerHTML = `
            <a class="page-link" href="#" onclick="changePage(${data.currentPage + 1}); return false;">
                Sonraki
            </a>
        `;
        pagination.appendChild(nextLi);
    }

    static updateSortIcons() {
        document.querySelectorAll('.fa-sort, .fa-sort-up, .fa-sort-down').forEach(icon => {
            icon.className = 'fas fa-sort';
        });

        const activeIcon = document.getElementById(`sort-${currentSort.column}`);
        if (activeIcon) {
            activeIcon.className = `fas fa-sort-${currentSort.direction === 'asc' ? 'up' : 'down'}`;
        }
    }

    static displayCustomers(data) {
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
    }
}

// Form manager'ı oluştur
const formManager = createFormManager();

// Dışa aktar
window.CustomerUI = CustomerUI;
window.UI_CONFIG = UI_CONFIG;
window.formManager = formManager;