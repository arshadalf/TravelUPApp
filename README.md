#  Flight Booking Intent Detection and Personalization – AI Assignment

##  Objective

Build a system that:
1. Predicts whether a user will book a flight based on session behavior.
2. Suggests personalized destinations or travel offers.

This demonstrates application of **Machine Learning + .NET** in the **TravelTech** domain.

---

##  Machine Learning Workflow

###  1. Dataset (Synthetic)

We created a dataset with the following features:

| Feature                 | Type    | Description                                   |
|------------------------|---------|-----------------------------------------------|
| user_id                | string  | Unique identifier per user                    |
| session_duration       | float   | Time on site (minutes)                        |
| pages_visited          | int     | Number of pages visited                       |
| search_origin          | string  | City user searched from                       |
| search_destination     | string  | Destination city                              |
| travel_dates_flexibility | binary | 1 = flexible dates                            |
| device_type            | string  | Mobile / Desktop / Tablet                     |
| clicked_offer          | binary  | 1 = clicked a promo                           |
| booking_made           | binary  | ✅ Target: 1 if booking was made              |

> 🔧 Synthetic data was generated using `pandas` and `numpy` with realistic distributions.

---

### 🔶 2. Model Selection: `XGBoostClassifier`

- **Why XGBoost?**
  - Handles both categorical + numeric data (after preprocessing)
  - Excellent performance on binary classification
  - Robust to imbalanced data
  - Fast training with great accuracy and generalization

---

### 🔶 3. Data Preprocessing

- Label encoded `search_origin`, `search_destination`, `device_type`
- Normalized numeric values
- Target: `booking_made`

---

### 🔶 4. Training the Model (`train_model.py`)

- Used `XGBoostClassifier` from `xgboost`
- Split data: 80% train / 20% test
- Evaluation metrics:
  - Precision
  - Recall
  - F1-score

✅ Model trained and saved as `booking_model.pkl`  
✅ Accuracy ~86% on test set

---

### 🔶 5. Convert Model to ONNX (`convert_to_onnx.py`)

- Used `skl2onnx` to convert XGBoost model to ONNX format
- Saved as `booking_model.onnx`
- ONNX is a portable model format that runs in multiple environments (.NET, Python, mobile, etc.)

---

## 🧩 .NET Integration (ASP.NET Core)

### 🔧 Tech Stack
- ASP.NET Core Razor Pages
- C#
- Microsoft.ML.OnnxRuntime
- Bootstrap Chart for visualization

---

### 🧠 ONNX Runtime in .NET

#### Sample Inference Code:

```csharp
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

float[] inputData = new float[] { 12.5f, 10f, 1f, 0f, 1f, 0f, 1f }; 

using var session = new InferenceSession("booking_model.onnx");
var inputMeta = session.InputMetadata;

var inputs = new List<NamedOnnxValue>
{
    NamedOnnxValue.CreateFromTensor("input",
        new DenseTensor<float>(inputData, new int[] { 1, inputData.Length }))
};

using var results = session.Run(inputs);
float prediction = results.First().AsEnumerable<float>().First();
Console.WriteLine($"Prediction: {prediction}");
