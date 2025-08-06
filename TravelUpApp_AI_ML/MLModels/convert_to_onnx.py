import joblib
import onnxmltools
from onnxmltools.convert import convert_xgboost
from onnxmltools.convert.common.data_types import FloatTensorType

# Load trained XGBoost model
model = joblib.load("booking_model.pkl")

# Define input shape: adjust 4 if you have different number of features
initial_type = [('input', FloatTensorType([None, 4]))]

# Convert to ONNX
onnx_model = onnxmltools.convert_xgboost(model, initial_types=initial_type)

# Save the ONNX model
with open("booking_model.onnx", "wb") as f:
    f.write(onnx_model.SerializeToString())

print("XGBoost model successfully converted to ONNX.")
