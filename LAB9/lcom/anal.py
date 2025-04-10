import pandas as pd

# Load the CSV
df = pd.read_csv('output/TypeMetrics.csv')

# Rename columns for convenience if needed
df.columns = [col.strip() for col in df.columns]

LCOM1_THRESHOLD = 10
LCOM5_THRESHOLD = 0.6

# Flag classes with high LCOM1 or LCOM5
df['High_LCOM1'] = df['LCOM1'] > LCOM1_THRESHOLD
df['High_LCOM5'] = df['LCOM5'] > LCOM5_THRESHOLD

# Filter high-cohesion concern classes
high_lcom_classes = df[(df['High_LCOM1']) | (df['High_LCOM5'])]

# Print summary
print("=== Classes with high LCOM values ===")
print(high_lcom_classes[['Type Name', 'Package Name', 'LCOM1', 'LCOM5']])

# Optional: save to CSV
high_lcom_classes.to_csv('high_lcom_classes.csv', index=False)
