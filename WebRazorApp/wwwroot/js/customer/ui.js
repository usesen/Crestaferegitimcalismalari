class CustomerUI {
    // Loading göstergesi
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

    // Alert gösterme
    static showAlert(type, message) {
        toastr.options = UI_CONFIG.toastr;
        toastr[type](message);
    }

    // Müşteri listesini görüntüleme
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

    // Sayfalama güncelleme
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

    // Sıralama ikonlarını güncelleme
    static updateSortIcons(currentSort) {
        document.querySelectorAll('.fa-sort, .fa-sort-up, .fa-sort-down').forEach(icon => {
            icon.className = 'fas fa-sort';
        });

        const activeIcon = document.getElementById(`sort-${currentSort.column}`);
        if (activeIcon) {
            activeIcon.className = `fas fa-sort-${currentSort.direction === 'asc' ? 'up' : 'down'}`;
        }
    }

    // Modal işlemleri
    static initializeModals() {
        const customerModalElement = document.getElementById('showCustomerModal');
        if (customerModalElement) {
            window.showCustomerModal = new bootstrap.Modal(customerModalElement);
            customerModalElement.addEventListener('hidden.bs.modal', () => {
                this.resetModalState();
            });
        }

        const deleteModalElement = document.getElementById('deleteConfirmModal');
        if (deleteModalElement) {
            window.deleteConfirmModal = new bootstrap.Modal(deleteModalElement);
        }
    }

    static resetModalState() {
        const form = document.getElementById('createCustomerForm');
        if (form) {
            form.reset();
            form.querySelectorAll('.form-control').forEach(input => {
                input.classList.remove('is-valid', 'is-invalid');
            });
            form.querySelectorAll('.invalid-feedback').forEach(error => {
                error.textContent = '';
            });
        }
    }

    // Form işlemleri
    static addResetButton(formId) {
        const form = document.getElementById(formId);
        if (!form) return;

        const resetBtn = document.createElement('button');
        resetBtn.type = 'button';
        resetBtn.className = 'btn btn-secondary me-2';
        resetBtn.innerHTML = '<i class="fas fa-undo me-1"></i> Temizle';
        resetBtn.onclick = () => {
            form.reset();
            form.querySelectorAll('.is-valid, .is-invalid').forEach(el => {
                el.classList.remove('is-valid', 'is-invalid');
            });
            form.querySelectorAll('.invalid-feedback').forEach(el => {
                el.textContent = '';
            });
        };

        const modalFooter = document.querySelector('#showCustomerModal .modal-footer');
        if (modalFooter) {
            modalFooter.insertBefore(resetBtn, modalFooter.firstChild);
        }
    }

    // CSV Export işlemleri
    static prepareCSVContent(data) {
        const headers = [
            'Ad', 'Soyad', 'Email', 'Telefon', 'Şirket', 'Pozisyon',
            'Adres', 'Şehir', 'Ülke', 'Posta Kodu',
            'Borç', 'Alacak', 'Bakiye Borç', 'Bakiye Alacak', 'Notlar'
        ];

        const csvRows = [
            headers.join(';'),
            ...data.items.map(customer => [
                customer.firstName || '',
                customer.lastName || '',
                customer.email || '',
                formatPhone(customer.phone) || '',
                customer.company || '',
                customer.position || '',
                customer.address || '',
                customer.city || '',
                customer.country || '',
                customer.postalCode || '',
                this.formatMoneyForCSV(customer.debt),
                this.formatMoneyForCSV(customer.credit),
                this.formatMoneyForCSV(customer.balanceDebt),
                this.formatMoneyForCSV(customer.balanceCredit),
                customer.notes || ''
            ].join(';'))
        ];

        return '\ufeff' + csvRows.join('\n');
    }

    static formatMoneyForCSV(value) {
        if (!value) return '0';
        return Number(value)
            .toLocaleString('tr-TR', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            })
            .replace(/\./g, '*')
            .replace(/,/g, '.')
            .replace(/\*/g, ',');
    }

    static downloadCSV(content, searchParams) {
        const now = new Date();
        const dateStr = now.toISOString()
            .replace(/T/, '_')
            .replace(/\..+/, '')
            .replace(/:/g, '-');

        let fileName = `Musteriler_${dateStr}`;
        if (searchParams.name || searchParams.company || searchParams.country) {
            fileName += '_Filtered';
        }
        fileName += '.csv';

        const blob = new Blob([content], { type: 'text/csv;charset=utf-8;' });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = fileName;
        link.style.display = 'none';

        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}

// Dışa aktar
window.CustomerUI = CustomerUI;