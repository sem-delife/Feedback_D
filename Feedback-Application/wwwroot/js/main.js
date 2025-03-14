let generatedCodeValue = ''; // Variable für den generierten Code

function generateUniqueCode() {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    let code = '';
    for (let i = 0; i < 5; i++) {
        const randomIndex = Math.floor(Math.random() * characters.length);
        code += characters[randomIndex];
    }
    generatedCodeValue = code; // Speichert den generierten Code in der Variable
    return code;
}

function setGeneratedCode(elementId) {
    const generatedCodeElement = document.getElementById(elementId);
    if (generatedCodeElement) {
        generatedCodeValue = generateUniqueCode(); // Aktualisiert die Variable
        generatedCodeElement.textContent = generatedCodeValue; // Setzt den Code ins HTML-Element
    }
}

// Funktion zum Weiterleiten zur Feedback-Seite mit Code
function redirectToPage() {
    let inputField = document.getElementById("codeInput");
    if (!inputField) return;

    let code = inputField.value.trim();
    if (code) {
        window.location.href = `/FeedbackPages/FirstFeedbackPages?Code=${encodeURIComponent(code)}`;
    }
}

// Event-Listener für ENTER-Taste im Code-Input-Feld
document.addEventListener('DOMContentLoaded', function () {
    let inputField = document.getElementById("codeInput");
    if (inputField) {
        inputField.addEventListener("keypress", function (event) {
            if (event.key === "Enter") {
                event.preventDefault(); // Verhindert das Standard-Submit-Verhalten
                redirectToPage(); // Feedback-Bogen öffnen
            }
        });
    }

    setGeneratedCode('generatedCode');

    const steps = document.querySelectorAll('.modal-step'); // Alle Schritte
    const prevBtn = document.getElementById('prevBtn');
    const nextBtn = document.getElementById('nextBtn');
    let currentStep = 0; // Start bei Schritt 0

    function updateStep() {
        steps.forEach((step, index) => {
            step.classList.toggle('d-none', index !== currentStep);
        });

        prevBtn.classList.toggle('d-none', currentStep === 0);
        nextBtn.textContent = currentStep === steps.length - 1 ? 'Absenden' : 'Weiter';
    }

    nextBtn.addEventListener('click', () => {
        if (currentStep < steps.length - 1) {
            currentStep++;
            updateStep();
        } else {
            // Validierung vor dem Absenden
            let selectedClass = document.getElementById('classDropdown').value;
            let selectedYear = document.getElementById('yearDropdown').value;
            let selectedSchoolYear = document.getElementById('schoolYear').value;
            let selectedAbteilung = document.getElementById('Abteilung').value;
            let selectedFach = document.getElementById('Fach').value;

            if (!selectedClass || !selectedYear || !selectedSchoolYear || !selectedAbteilung || !selectedFach) {
                alert("Bitte füllen Sie alle Felder aus, bevor Sie fortfahren.");
                return;
            }

            // Die Formularfelder setzen
            document.getElementById('UserID').value = document.getElementById('userHiddenId')?.value || 1;
            document.getElementById('selectedClass').value = selectedClass;
            document.getElementById('selectedYear').value = selectedYear;
            document.getElementById('schoolYearInput').value = selectedSchoolYear;
            document.getElementById('AbteilungInput').value = selectedAbteilung;
            document.getElementById('FachInput').value = selectedFach;
            document.getElementById('generatedCodeInput').value = generatedCodeValue;

            console.log("Form wird abgeschickt mit:", {
                UserID: document.getElementById('UserID').value,
                SelectedClass: document.getElementById('selectedClass').value,
                SelectedYear: document.getElementById('selectedYear').value,
                SchoolYear: document.getElementById('schoolYearInput').value,
                Abteilung: document.getElementById('AbteilungInput').value,
                Fach: document.getElementById('FachInput').value,
                Code: document.getElementById('generatedCodeInput').value
            });

            // Modal schließen
            const modal = document.getElementById('multiStepModal');
            const bootstrapModal = bootstrap.Modal.getInstance(modal);
            bootstrapModal.hide();

            // Formular absenden über versteckten Button
            document.getElementById('formSubmitButton').click();
        }
    });

    prevBtn.addEventListener('click', () => {
        if (currentStep > 0) {
            currentStep--;
            updateStep();
        }
    });

    updateStep();
});
