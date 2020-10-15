export function typedAction<T extends string>(type: T): { type: T };
export function typedAction<T extends string, P extends any>(
  type: T,
  payload: P
): { type: T; payload: P };
export function typedAction(type: string, payload?: any) {
    return { type, payload };
  }

export const STUDENT_INFO = 'STUDENT_INFO';

export type UserState = {
    userId: string | null;
};

export const studentInfo = (userId: string) => {
    return typedAction(STUDENT_INFO, userId)
};

export type UserAction = ReturnType<typeof studentInfo>; //<typeof model | type anothermodel>;

// type StudentInfo {
//     type: typeof STUDENT_INFO,
//     payload: string | null
// };



