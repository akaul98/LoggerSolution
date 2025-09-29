
3. **Check Log Files**  
Log files are created in `LogConsoleApp/Logs/` with names like `log_YYYY-MM-DD.txt`.

## How It Works

- The `Logger` class reads allowed log levels from `Logger.config`.
- Only messages matching allowed levels are logged.
- Log entries are written to both the console and a daily log file.
