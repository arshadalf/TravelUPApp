import pandas as pd
from xgboost import XGBClassifier
import joblib

# Sample synthetic data
data = {
    'session_duration': [12.5, 3.1, 8.4, 2.0, 15.2],
    'pages_visited': [10, 3, 7, 2, 12],
    'travel_dates_flexibility': [1, 0, 1, 0, 1],
    'clicked_offer': [1, 0, 1, 0, 1],
    'booking_made': [1, 0, 1, 0, 1]  # target
}

df = pd.DataFrame(data)

# Features and target
X = df.drop('booking_made', axis=1)
y = df['booking_made']

# Train XGBoost classifier
model = XGBClassifier(use_label_encoder=False, eval_metric='logloss')
model.fit(X, y)

# Save the trained model to 'booking_model.pkl'
joblib.dump(model, 'booking_model.pkl')

print("Model trained and saved as booking_model.pkl")
